using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Models
{
    public class Offer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Item> Items { get; set; } = new();
        public string Description { get; set; }
        public int PointCost { get; set; }
    }
}
