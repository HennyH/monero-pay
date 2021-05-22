using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoneroPay.API.Configuration;
using MoneroPay.API.Models;
using MoneroPay.Database;
using MoneroPay.WalletRpc;
using MoneroPay.WalletRpc.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("wallet")]
    public class WalletRpcController : ControllerBase
    {
        private readonly MoneroPayContext _moneroPayContext;
        private readonly MoneroPayConfiguration _moneroPayConfiguration;
        private readonly ILogger<WalletRpcController> _logger;
        private const int MAX_CONTAINER_COUNTER = 5;
        private readonly IWalletRpcProcessClientFactory _walletRpcClientFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        public WalletRpcController(ILogger<WalletRpcController> logger, MoneroPayConfiguration moneroPayConfiguration, MoneroPayContext MoneroPayContext, IWalletRpcProcessClientFactory walletRpcClientFactory, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _moneroPayConfiguration = moneroPayConfiguration;
            _moneroPayContext = MoneroPayContext;
            _walletRpcClientFactory = walletRpcClientFactory;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("json_rpc")]
        public async Task<ActionResult> GetWalletRpcUri([FromBody] ApiWalletRpcRequest walletRpcRequest, CancellationToken cancellationToken = default)
        {
            var rpcClient = await _walletRpcClientFactory.CreateClientAsync(
                moneroWalletRpcPath: _moneroPayConfiguration.MonerodWalletRpcPath,
                cliParameters: new WalletRpcCliParameters
                {
                    WalletFile = walletRpcRequest.WalletFilename,
                    RpcLogin = $"{walletRpcRequest.RpcUsername}:{walletRpcRequest.RpcPassword}",
                    Testnet = walletRpcRequest.Testnet,
                    DaemonHost = walletRpcRequest.DaemonHost ?? _moneroPayConfiguration.MonerodHost,
                    DaemonPort = walletRpcRequest.DaemonPort ?? _moneroPayConfiguration.MonerodPort,
                    Password = walletRpcRequest.WalletPassword
                },
                portRangeLower: _moneroPayConfiguration.WalletRpcPortStart,
                portRangeUpper: _moneroPayConfiguration.WalletRpcPortEnd);
            var rpcResponse = await rpcClient.JsonRpcAsync(walletRpcRequest.Method, walletRpcRequest.Params, walletRpcRequest.Id, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            return new FileContentResult(Encoding.UTF8.GetBytes(rpcResponse), MediaTypeNames.Application.Json);
        }
    }
}
