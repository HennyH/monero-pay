using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MoneroPay.WalletRpc.Models;

namespace MoneroPay.WalletRpc
{
    public interface IWalletRpcClient
    {
        public string JsonRpcUri { get; }
        public Task<HttpResponseMessage> JsonRpcAsync<TParameters>(
                string method,
                TParameters parameters,
                string? id = default,
                bool waitForHealthCheck = true,
                CancellationToken cancellationToken = default);
        public Task<IMoneroRpcResponse<TResult>> JsonRpcAsync<TParameters, TResult>(
                string method,
                TParameters parameters,
                string? id = default,
                bool waitForHealthCheck = true,
                CancellationToken cancellationToken = default)
            where TResult : class
            where TParameters : class;
    }
}