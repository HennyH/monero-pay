using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneroPay.Database
{
    public class Wallet
    {
        public int Id { get; set; }
        public ICollection<IntegratedAddress> IntegratedAddresses { get; set; } = new List<IntegratedAddress>();
        [Required]
        public byte[]? AesIv { get; set; }
        [Required]
        public byte[]? KeysFileBytes { get; set; }
    }
}