using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MoneroPay.API.Configuration;
using MoneroPay.API.Extensions;
using MoneroPay.API.Utilities;

namespace MoneroPay.API.WalletRpc
{
    public class WalletRpcProcess : IDisposable
    {
        private readonly ILogger<WalletRpcProcess> _logger;
        private readonly WalletRpcCliParameters _cliParameters;
        private readonly IMapper _mapper;
        private readonly ICollection<string> _rpcInformationData = new List<string>();
        private readonly ICollection<string> _rpcWarningData = new List<string>();
        private readonly ICollection<string> _rpcDebugData = new List<string>();
        private readonly ICollection<string> _rpcErrorData = new List<string>();
        private readonly ICollection<string> _rpcStdoutData = new List<string>();
        private readonly ICollection<string> _rpcStderrData = new List<string>();
        private Process? _process;
        private int? _port;
        private bool disposed;
        public IEnumerable<string> InformationData => _rpcInformationData;
        public IEnumerable<string> WarningData => _rpcWarningData;
        public IEnumerable<string> DebugData => _rpcDebugData;
        public IEnumerable<string> ErrorData => _rpcErrorData;
        public IEnumerable<string> StdoutData => _rpcStdoutData;
        public IEnumerable<string> StderrData => _rpcErrorData;
        public int? RpcPort => _port;
        
        internal WalletRpcProcess(ILogger<WalletRpcProcess> logger, IMapper mapper, WalletRpcCliParameters cliParameters)
        {
            if (cliParameters.WalletFile == null) throw new ArgumentNullException(nameof(cliParameters.WalletFile), "Wallet processes must be launched with a --wallet-file parameter");
            if (cliParameters.RpcBindPort != null) throw new ArgumentException(nameof(cliParameters.RpcBindPort), "Support for launching a wallet rpc client on a preconfigured port has not been implemented");
            _cliParameters = cliParameters;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<bool> StartAsync()
        {
            if (_process != null) throw new NotImplementedException("Restarting the process has not been implemented");

            // Have a look for a process running against this wallet. (need to validate we can connect with user/name + password tho),
            // we should probably put user/pass/wallet into the CliParamters and only expose a subset to user rather than special casing
            // at this point

            _port = IpUtilities.GetAvailablePort(lowerPort: 28090, upperPort: 28099);
            if (_port == null) throw new SystemException("There are no free ports available to spwan a monero-wallet-rpc process");

            // TODO(HH): This obv. needs to be parameterized
            var startInfo = new ProcessStartInfo(@"C:\Program Files\Monero GUI Wallet\monero-wallet-rpc.exe");
            startInfo.ArgumentList.AddRange(CliParameterHelpers.ToArgumentList(_cliParameters with { RpcBindPort = _port }));
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;

            _process = new Process { StartInfo = startInfo };
            _process.OutputDataReceived +=  CreateDataRecievedLoggingHandler(LogLevel.Information);
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

        private DataReceivedEventHandler CreateDataRecievedLoggingHandler(LogLevel logLevel) => new DataReceivedEventHandler((_, e) =>
        {
            if (string.IsNullOrEmpty(e.Data)) return;
            _logger.Log(logLevel, $"({_cliParameters.WalletFile}) {e.Data}");
            var bytes = Encoding.UTF8.GetBytes(e.Data);
            (logLevel == LogLevel.Error ? _rpcStderrData : _rpcStdoutData).Add(e.Data);
        });

        private LogLevel TryGetRpcLogLevel(string rpcMessage, LogLevel @default)
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