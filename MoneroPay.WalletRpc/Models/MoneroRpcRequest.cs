using System.Text.Json.Serialization;

namespace MoneroPay.WalletRpc.Models
{
    public class MoneroRpcRequest<TParameters>
    {
        public const string DEFAULT_ID = "0";
        public const string DEFAULT_JSON_RPC = "2.0";
        public MoneroRpcRequest(string method, TParameters parameters, string? id = null, string? jsonRpc = null)
        {
            this.JsonRpc = jsonRpc ?? DEFAULT_JSON_RPC;
            this.Id = id ?? DEFAULT_ID;
            this.Method = method;
            this.Params = parameters;
        }
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "2.0";
        [JsonPropertyName("id")]
        public string Id { get; set; } = "0";
        [JsonPropertyName("method")]
        public string Method { get; set; }
        [JsonPropertyName("params")]
        public TParameters Params { get; set; }
    }
}