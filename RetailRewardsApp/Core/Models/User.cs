using System;
using System.Collections.Generic;
using System.Text;
namespace RetailRewardsApp.Core.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int Points { get; set; }
        public List<Transaction> Transactions { get; set;} = new();
        public List<Notification> Notifications { get; set; } = new();
        public Guid RegisteredLocationId { get; set; } 
    }
}
