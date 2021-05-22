using System.ComponentModel.DataAnnotations;

namespace MoneroPay.Database
{
    public class IntegratedAddress
    {
        public int Id { get; set; }
        [Required]
        public int? WalletId { get; set; }
        [Required]
        public string? Reference { get; set; }
        public string? Message { get; set; }
        public ulong? Amount { get; set; }
        [Required]
        public Wallet? Wallet { get; set; }
    }
}