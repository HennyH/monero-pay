using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoneroPay.WalletRpc.Models
{
    public class EmptyRpcResult
    { }

    public class GetAddressRpcResult
    {
        public GetAddressRpcResult(string address, IEnumerable<Subaddress> addresses)
        {
            this.Address = address;
            this.Addresses = addresses;
        }

        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("addresses")]
        public IEnumerable<Subaddress> Addresses { get; set; }
        public class Subaddress
        {
            public Subaddress(string address, string label, ulong addressIndex, bool used)
            {
                this.Address = address;
                this.Label = label;
                this.AddressIndex = addressIndex;
                this.Used = used;
            }

            [JsonPropertyName("address")]
            public string Address { get; set; }
            [JsonPropertyName("label")]
            public string Label { get; set; }
            [JsonPropertyName("address_index")]
            public ulong AddressIndex { get; set; }
            [JsonPropertyName("used")]
            public bool Used { get; set; }

        }
    }
}