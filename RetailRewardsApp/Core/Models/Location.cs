using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Models
{
    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Business Business { get; set; }
        public string Address { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
