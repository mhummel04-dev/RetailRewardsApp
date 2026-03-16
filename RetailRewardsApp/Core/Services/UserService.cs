using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class UserService
    {
        FakeDatabaseService FakeDB = new FakeDatabaseService();

        public User GetUserByEmail(string Email)
        {
            User User = FakeDB.FakeUserTable.FirstOrDefault(i => i.Email == Email);
            return User;
        }

        public User GetUserById(Guid Id)
        {
            User User = FakeDB.FakeUserTable.FirstOrDefault(i => i.Id == Id);
            return User;
        }

        public List<Transaction> GetUserTransactionHistoryById(Guid Id)
        {
            User User = FakeDB.FakeUserTable.FirstOrDefault(i => i.Id == Id);
            return User.Transactions;
        }

        public List<Notification> GetUserNotificationsById(Guid Id)
        {
            User User = FakeDB.FakeUserTable.FirstOrDefault(i => i.Id == Id);
            return User.Notifications;
        }
    }
}
