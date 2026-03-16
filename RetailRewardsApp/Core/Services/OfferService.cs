using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class OfferService
    {
        FakeDatabaseService FakeDB = new FakeDatabaseService();

        public Offer GetOfferById(Guid Id)
        {
            Offer Offer = FakeDB.FakeOfferTable.FirstOrDefault(i => i.Id == Id);
            return Offer;
        }
    }
}
