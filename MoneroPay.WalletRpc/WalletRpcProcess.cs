using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MoneroPay.SharedUtilities;
using MoneroPay.WalletRpc.Models;

namespace MoneroPay.WalletRpc
{
    public class WalletRpcProcess : IDisposable
    {
        private readonly WalletRpcCliParameters _cliParameters;
        private readonly string _moneroWalletRpcPath;
        private readonly ushort _portRangeLower;
        private readonly ushort _portRangeUpper;
        private readonly ILogger<WalletRpcProcess> _logger;
        private readonly ICollection<string> _rpcInformationData = new List<string>();
        private readonly ICollection<string> _rpcWarningData = new List<string>();
        private readonly ICollection<string> _rpcDebugData = new List<string>();
        private readonly ICollection<string> _rpcErrorData = new List<string>();
        private readonly ICollection<string> _rpcStdoutData = new List<string>();
        private readonly ICollection<string> _rpcStderrData = new List<string>();
        private Process? _process;
        private ushort? _port;
        private bool disposed;
        public IEnumerable<string> InformationData => _rpcInformationData;
        public IEnumerable<string> WarningData => _rpcWarningData;
        public IEnumerable<string> DebugData => _rpcDebugData;
        public IEnumerable<string> ErrorData => _rpcErrorData;
        public IEnumerable<string> StdoutData => _rpcStdoutData;
        public IEnumerable<string> StderrData => _rpcErrorData;
        public string RpcProtocol => _cliParameters.RpcSsl == MoneroSslSetting.Disabled ? "http" : "https";
        public string RpcHost => _cliParameters?.RpcBindIp ?? "localhost";
        public int? RpcPort => _port;
        public string RpcUri => $"{RpcProtocol}://{RpcHost}{(RpcPort == null ? string.Empty : $":{RpcPort}")}/json_rpc";

        internal WalletRpcProcess(
                ILogger<WalletRpcProcess> logger,
                string moneroWalletRpcPath,
                ushort portRangeLower,
                ushort portRangeUpper,
                WalletRpcCliParameters cliParameters)
        {
            if (cliParameters.WalletFile == null) throw new ArgumentException("Wallet processes must be launched with a --wallet-file parameter", nameof(cliParameters));
            if (cliParameters.RpcBindPort != null) throw new ArgumentException("Support for launching a wallet rpc client on a preconfigured port has not been implemented", nameof(cliParameters));
            if (!File.Exists(moneroWalletRpcPath)) throw new ArgumentException($"The monero wallet rpc program with path {moneroWalletRpcPath} could not be found.", nameof(moneroWalletRpcPath));
            _cliParameters = cliParameters;
            _logger = logger;
            _moneroWalletRpcPath = moneroWalletRpcPath;
            _portRangeLower = portRangeLower;
            _portRangeUpper = portRangeUpper;
        }

        public Task<bool> StartAsync()
        {
            if (_process != null) throw new NotImplementedException("Restarting the process has not been implemented");

            // Have a look for a process running against this wallet. (need to validate we can connect with user/name + password tho),
            // we should probably put user/pass/wallet into the CliParamters and only expose a subset to user rather than special casing
            // at this point

            _port = _cliParameters.RpcBindPort ?? IpUtilities.GetAvailablePort(lowerPort: _portRangeLower, upperPort: _portRangeUpper);
            if (_port == null) throw new SystemException("There are no free ports available to spwan a monero-wallet-rpc process");

            var startInfo = new ProcessStartInfo(_moneroWalletRpcPath);
            startInfo.ArgumentList.AddRange(CliParameterHelpers.ToArgumentList(_cliParameters with { RpcBindPort = _port }));
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;

            _process = new Process { StartInfo = startInfo };
            _process.OutputDataReceived += CreateDataRecievedLoggingHandler(LogLevel.Information);
            _process.ErrorDataReceived += CreateDataRecievedLoggingHandler(LogLevel.Error);

            var startOk = _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
            return Task.FromResult(startOk);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                _process?.Kill();
                _process?.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private DataReceivedEventHandler CreateDataRecievedLoggingHandler(LogLevel logLevel) => new((_, e) =>
        {
            if (string.IsNullOrEmpty(e.Data)) return;
            _logger.Log(logLevel, $"({_cliParameters.WalletFile}) {e.Data}");
            var bytes = Encoding.UTF8.GetBytes(e.Data);
            (logLevel == LogLevel.Error ? _rpcStderrData : _rpcStdoutData).Add(e.Data);
            GetStreamForLogLevel(TryGetRpcLogLevel(e.Data, logLevel))?.Add(e.Data);
        });

        private static LogLevel TryGetRpcLogLevel(string rpcMessage, LogLevel @default)
        {
            // monero log messages are in the following format:
            // "2021-05-15 12:57:25.639\t<I|D|E|...> <message>"
            //                           ^
            //                           |
            //    We're going to bse the log level off of this character.
            var levelCharacater = rpcMessage.Length >= 25 ? rpcMessage[24] : 'I';
            if (levelCharacater == 'I') return LogLevel.Information;
            if (levelCharacater == 'W') return LogLevel.Warning;
            if (levelCharacater == 'E') return LogLevel.Error;
            if (levelCharacater == 'D') return LogLevel.Debug;
            return @default;
        }

        private ICollection<string>? GetStreamForLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Information => _rpcInformationData,
                LogLevel.Warning => _rpcWarningData,
                LogLevel.Error => _rpcErrorData,
                LogLevel.Debug => _rpcDebugData,
                _ => null
            };
        }
    }
}