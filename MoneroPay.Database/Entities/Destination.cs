using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneroPay.Database
{
    public class Destination
    {
        public int Id { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public ulong? Amount { get; set; }
        public ICollection<RedistributionScheme> RedistributionSchemes { get; set; } = new List<RedistributionScheme>();
    }
}