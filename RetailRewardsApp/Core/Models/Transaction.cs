using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Models
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public Business Business { get; set; }
        public Location Location { get; set; }
        public List<TransactionItem> ItemsPurchased { get; set; } = new();
        public decimal TotalSpent { get; set; }
        public List<Offer> OffersUsed { get; set; } = new();
        public int PointsGained { get; set; }
        public int PointsUsed { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
