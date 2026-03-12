using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class ItemService
    {
        Business FakeBusiness1;
        Models.Location FakeLocation1;

        public ItemService()
        {
            FakeBusiness1 = new Business { Name = "Jaden Inc" };
            FakeLocation1 = new Models.Location { Business = FakeBusiness1 };
            FakeLocation1.Inventory = new List<Item>()
            {
                new Item
                {

                    Name = "Sneakers",
                    Price = 49.99M,
                    Description = "2 individual shoes sold together, that go on your feet!",
                    Stock = 15,
                    Location = FakeLocation1

                },

                new Item
                {

                    Name = "Shampoo",
                    Price = 8.99M,
                    Description = "Liquid you put in your hair to clean your hair and scalp!",
                    Stock = 30,
                    Location = FakeLocation1

                }
            };

        }

        public List<Item> GetItemsForLocation(Guid LocationId)
        {
            //FakeLocationItems = db.select Location.Inventory where Location.Id == LocationId;

            return FakeLocation1.Inventory;
        }


    }
}
