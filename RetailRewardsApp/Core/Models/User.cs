using System;
using System.Collections.Generic;
using System.Text;
namespace RetailRewardsApp.Core.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Points { get; set; }
        public List<Transaction> Transactions { get; set;} = new();
    }
}
