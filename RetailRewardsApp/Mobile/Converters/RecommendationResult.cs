using RetailRewardsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Mobile.Converters
{
    public class RecommendationResult
    {
        public List<Item> Items { get; set; } = new();
        public List<Offer> Offers { get; set; } = new();
    }
}
