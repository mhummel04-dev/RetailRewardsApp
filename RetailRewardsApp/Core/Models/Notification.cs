using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Models
{
    public class Notification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        public List<Item> Items { get; set; } = new();
        public List<Offer> Offers { get; set; } = new();
        public DateTime Timestamp { get; set; }
        public bool isRead { get; set; }
    }
}
