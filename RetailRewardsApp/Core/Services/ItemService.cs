using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class ItemService
    {
        FakeDatabaseService FakeDB = new FakeDatabaseService();
        public ItemService() {}

        public Item GetItemById(Guid Id)
        {
            Item item = FakeDB.FakeItemTable.FirstOrDefault(i => i.Id == Id);
            return item;
        }
    }
}
