using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class SessionService
    {
        FakeDatabaseService FakeDB = new FakeDatabaseService();
        public User LoggedInUser { get; private set; }
        public Models.Location RegisteredLocation { get; private set; }



        public bool Login(string Email, string Password)
        {
            User User = FakeDB.FakeUserTable.FirstOrDefault(i => (i.EmailAddress == Email) && (i.Password == Password));
            if (User != null)
            {
                LoggedInUser = User;
                RegisteredLocation = FakeDB.FakeLocationTable.FirstOrDefault(i => i.Id == LoggedInUser.RegisteredLocationId);
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
