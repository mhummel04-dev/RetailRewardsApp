using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Models
{
    public class TransactionItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ItemId { get; set; } = Guid.Empty;
        public string NameAtPurchase { get; set; }
        public decimal PriceAtPurchase { get; set; }
        public string DescriptionAtPurchase { get; set; }
        public int QuantityPurchased { get; set; }
    }
}
