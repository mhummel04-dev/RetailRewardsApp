using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class ItemService
    {
        private readonly SessionService _sessionService;
        public ItemService(SessionService sessionService) 
        {
            _sessionService = sessionService;
        }

        public Item GetItemById(Guid Id)
        {
            Item item = _sessionService.FakeDB.FakeItemTable.FirstOrDefault(i => i.Id == Id);
            return item;
        }
    }
}
