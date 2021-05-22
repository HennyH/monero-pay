using System.Collections.Generic;

namespace MoneroPay.Database
{
    public class RedistributionScheme
    {
        public int Id { get; set; }
        public int? IntegratedAddressId { get; set; }
        public IntegratedAddress? IntegratedAddress { get; set; }
        public ICollection<Destination> Destinations { get; set; } = new List<Destination>();
    }
}