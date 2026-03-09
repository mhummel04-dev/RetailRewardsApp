using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Models
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Business> Businesses { get; set; } = new();
    }
}
