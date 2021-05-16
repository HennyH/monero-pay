using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MoneroPay.API.Models.Monero;

namespace MoneroPay.API.WalletRpc
{
    public interface IWalletRpcClient
    {
        public string JsonRpcUri { get; }
        public IEnumerable<string> InformationLogs { get; }
        public IEnumerable<string> WarningLogs { get; }
        public IEnumerable<string> DebugLogs { get; }
        public IEnumerable<string> ErrorLogs { get; }
        public Task<string> JsonRpcAsTextAsync(
                string method,
                object parameters,
                string? id = default,
                CancellationToken cancellationToken = default);
        public Task<IMoneroRpcResponse<TResult>?> JsonRpcAsync<TParameters, TResult>(
                string method,
                TParameters parameters,
                string? id = default,
                CancellationToken cancellationToken = default)
            where TResult : class
            where TParameters : class;
    }
}