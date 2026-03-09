using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Models
{
    public class Business
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Company Company { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; } = new();
    }
}
