using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class OfferService
    {
        private readonly SessionService _sessionService;

        public OfferService(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public Offer GetOfferById(Guid Id)
        {
            Offer Offer = _sessionService.FakeDB.FakeOfferTable.FirstOrDefault(i => i.Id == Id);
            return Offer;
        }
    }
}
