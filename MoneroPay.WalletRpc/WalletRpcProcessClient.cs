using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace MoneroPay.WalletRpc
{
    public class WalletRpcProcessClient : WalletRpcClient, IWalletRpcProcessClient
    {
        private readonly Func<IEnumerable<string>> _getInformationLogs;
        private readonly Func<IEnumerable<string>> _getWarningLogs;
        private readonly Func<IEnumerable<string>> _getDebugLogs;
        private readonly Func<IEnumerable<string>> _getErrorLogs;
        public IEnumerable<string> InformationLogs => _getInformationLogs();
        public IEnumerable<string> WarningLogs => _getWarningLogs();
        public IEnumerable<string> DebugLogs => _getDebugLogs();
        public IEnumerable<string> ErrorLogs => _getErrorLogs();

        internal WalletRpcProcessClient(
                ILogger<WalletRpcClient> logger,
                string rpcUri,
                string rpcLogin,
                Func<IEnumerable<string>> getInformationLogs,
                Func<IEnumerable<string>> getWarningLogs,
                Func<IEnumerable<string>> getDebugLogs,
                Func<IEnumerable<string>> getErrorLogs)
            : base(logger, rpcUri, rpcLogin)
        {
            _getInformationLogs = getInformationLogs;
            _getWarningLogs = getWarningLogs;
            _getDebugLogs = getDebugLogs;
            _getErrorLogs = getErrorLogs;
        }
    }
}