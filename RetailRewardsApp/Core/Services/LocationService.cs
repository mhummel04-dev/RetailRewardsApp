using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class LocationService
    {
        FakeDatabaseService FakeDB = new FakeDatabaseService();
        public LocationService() {}

        public Models.Location GetLocationById(Guid Id)
        {
            Models.Location location = FakeDB.FakeLocationTable.FirstOrDefault(i => i.Id == Id);
            return location;
        }

        public List<Item> GetLocationInventoryById(Guid Id)
        {
            Models.Location location = FakeDB.FakeLocationTable.FirstOrDefault(i => i.Id == Id);
            return location.Inventory;
        }

        public List<Offer> GetLocationOffersById(Guid Id)
        {
            Models.Location location = FakeDB.FakeLocationTable.FirstOrDefault(i => i.Id == Id);
            return location.Offers;
        }
    }
}
