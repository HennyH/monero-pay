using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoneroPay.API.Configuration;
using MoneroPay.API.Models;
using MoneroPay.API.Models.Monero;
using MoneroPay.API.WalletRpc;
using MoneroPay.Database;

namespace API.Controllers
{
    [ApiController]
    [Route("wallet")]
    public class WalletRpcController : ControllerBase
    {
        private readonly MoneroPayContext _MoneroPayContext;
        private readonly ILogger<WalletRpcController> _logger;
        private const int MAX_CONTAINER_COUNTER = 5;
        private readonly IWalletRpcClientFactory _walletRpcClientFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        public WalletRpcController(ILogger<WalletRpcController> logger, MoneroPayContext MoneroPayContext, IWalletRpcClientFactory walletRpcClientFactory, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _MoneroPayContext = MoneroPayContext;
            _walletRpcClientFactory = walletRpcClientFactory;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("json_rpc")]
        public async Task<ActionResult> GetWalletRpcUri(
                [FromBody] ApiWalletRpcRequest walletRpcRequest,
                CancellationToken cancellationToken = default)
        {
            var rpcClient = await _walletRpcClientFactory.CreateClientAsync(new WalletRpcCliParameters
            {
                WalletFile = walletRpcRequest.WalletFilename,
                RpcLogin = $"{walletRpcRequest.RpcUsername}:{walletRpcRequest.RpcPassword}",
                Testnet = walletRpcRequest.Testnet,
                DaemonHost = walletRpcRequest.DaemonHost,
                DaemonPort = walletRpcRequest.DaemonPort,
                Password = walletRpcRequest.WalletPassword
            });
            var rpcResponse = await rpcClient.JsonRpcAsTextAsync(walletRpcRequest.Method, walletRpcRequest.Params, walletRpcRequest.Id, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            return new FileContentResult(Encoding.UTF8.GetBytes(rpcResponse), MediaTypeNames.Application.Json);
        }
    }
}
