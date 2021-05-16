using System;
using System.ComponentModel.DataAnnotations;

namespace MoneroPay.Database.Entities
{
    public class MoneroWalletRpcContainer
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Reference { get; set; }
        [Required]
        public string? ContainedId { get; set; }
        [Required]
        public int? Port { get; set; }
        [Required]
        public string? Uri { get; set; }
        [Required]
        public DateTime? SpwanedDate { get; set; }

    }
}