using System.Text.Json.Serialization;

namespace MoneroPay.API.Models
{
    public class ApiWalletRpcRequest
    {
        public ApiWalletRpcRequest(string walletFileName, string method)
        {
            this.WalletFilename = walletFileName;
            this.Method = method;
        }

        [JsonPropertyName("wallet_filename")]
        public string WalletFilename { get; set; }
        [JsonPropertyName("wallet_password")]
        public string WalletPassword { get; set; } = string.Empty;
        [JsonPropertyName("json_rpc")]
        public string JsonRpc { get; set; } = "2.0";
        [JsonPropertyName("id")]
        public string Id { get; set; } = "0";
        [JsonPropertyName("method")]
        public string Method { get; set; }
        [JsonPropertyName("params")]
        public dynamic? Params { get; set; }
        [JsonPropertyName("testnet")]
        public bool Testnet { get; set; } = false;
        [JsonPropertyName("daemon_host")]
        public string? DaemonHost { get; set; } = "localhost";
        [JsonPropertyName("daemon_port")]
        public ushort? DaemonPort { get; set; } = 28081;
        [JsonPropertyName("rpc_username")]
        public string RpcUsername {get;set;} = "user";
        [JsonPropertyName("rpc_password")]
        public string RpcPassword {get;set;} = "password";
        
    }
}