using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class UserSessionService
    {
        FakeDatabaseService FakeDB = new FakeDatabaseService();
        public User LoggedInUser { get; private set; }

        public bool Login(string Email, string Password)
        {
            User User = FakeDB.FakeUserTable.FirstOrDefault(i => (i.Email == Email) && (i.Password == Password));
            if (User != null)
            {
                LoggedInUser = User;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Logout()
        {
            LoggedInUser = null;
        }
    }
}
