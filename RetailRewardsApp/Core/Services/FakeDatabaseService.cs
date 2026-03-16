using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class FakeDatabaseService
    {

        // Fake Variable Declarations
        User FakeUser1, FakeUser2;
        Business FakeBusiness1, FakeBusiness2;
        Models.Location FakeLocation1, FakeLocation2;
        Item FakeItem1, FakeItem2, FakeItem3, FakeItem4;
        Offer FakeOffer1, FakeOffer2, FakeOffer3, FakeOffer4;
        Transaction FakeTransaction1;

        public List<User> FakeUserTable { get; set; }
        public List<Business> FakeBusinessTable { get; set; }
        public List<Models.Location> FakeLocationTable { get; set; }
        public List<Item> FakeItemTable { get; set; }
        public List<Offer> FakeOfferTable { get; set; }
        public List<Transaction> FakeTransactionTable { get; set; }

        public FakeDatabaseService()
        {
            FakeUserTable = new List<User> { FakeUser1, FakeUser2 };
            FakeBusinessTable = new List<Business> { FakeBusiness1, FakeBusiness2 };
            FakeLocationTable = new List<Models.Location> { FakeLocation1, FakeLocation2 };
            FakeOfferTable = new List<Offer> { FakeOffer1, FakeOffer2, FakeOffer3, FakeOffer4 };
            FakeItemTable = new List<Item> { FakeItem1, FakeItem2, FakeItem3, FakeItem4 };
            FakeTransactionTable = new List<Transaction> { FakeTransaction1 };


            // User Inits
            FakeUser1 = new User
            {
                Id = Guid.Parse("ac30925e-74b0-4526-a821-49578ed876ab"),
                FirstName = "Marthew",
                LastName = "Huemmel",
                EmailAddress = "marthew.d.huemmel02@gmail.com",
                Password = "password",
                PhoneNumber = "1234567890",
                RegisteredLocation = FakeLocation1
            };

            
            // Business Inits
            FakeBusiness1 = new Business 
            { 
                Id = Guid.Parse("861b12c9-7ee1-4dde-bee6-61a116efc113"),
                Name = "Jaden Inc" 
            };

            FakeBusiness2 = new Business 
            {
                Id = Guid.Parse("4ef7e01e-b17a-4778-9f9a-8bcadece5776"),
                Name = "Wyatt LLC" 
            };


            // Location Inits
            FakeLocation1 = new Models.Location
            {
                Id = Guid.Parse("6072a638-3a11-416c-bf8a-9343119d28df"),
                Business = FakeBusiness1
            };

            FakeLocation2 = new Models.Location 
            { 
                Id = Guid.Parse("41ff95b9-2537-4331-951a-6210409932b8"),
                Business = FakeBusiness2 
            };



            // Item / Inventory for Location Inits
            FakeItem1 = new Item
            {

                Id = Guid.Parse("c78e271a-612e-4268-8b8f-64b6fa5aac45"),
                Name = "Sneakers",
                Price = 49.99M,
                Description = "2 individual shoes sold together, that go on your feet!",
                Stock = 15,

            };

            FakeItem2 = new Item
            {

                Id = Guid.Parse("0de50d81-17cc-4ad6-9f15-daf8d748f73f"),
                Name = "Shampoo",
                Price = 8.99M,
                Description = "Liquid you put in your hair to clean your hair and scalp!",
                Stock = 30,

            };

            FakeItem3 = new Item
            {

                Id = Guid.Parse("0ecfb50c-d9ac-4b2e-a91b-23782abee1b0"),
                Name = "5 Pack Chicken Wings",
                Price = 3.99M,
                Description = "5 Uncooked chicken wings in a pack",
                Stock = 10,

            };

            FakeItem4 = new Item
            {

                Id = Guid.Parse("eb164e5d-ccfe-42fc-b8cb-b7314beb96f0"),
                Name = "Sandwich",
                Price = 5.99M,
                Description = "A premade Italian 6-inch Sub",
                Stock = 15,

            };

            FakeLocation1.Inventory = new List<Item>() {FakeItem1, FakeItem2};
            FakeLocation2.Inventory = new List<Item>() {FakeItem3, FakeItem4};



            // Offers for Location Inits
            FakeOffer1 = new Offer
            {
                Id = Guid.Parse("a3076424-0a90-49f9-964e-d6923688dcbc"),
                Items = new List<Item> { FakeLocation1.Inventory[0], FakeLocation1.Inventory[1] },
                Description = "50% off everything!"
            };

            FakeOffer2 = new Offer
            {
                Id = Guid.Parse("0f047bcb-e52f-40dc-b6c8-156dc031d95c"),
                Items = new List<Item> { FakeLocation1.Inventory[0] },
                Description = "Free Sneakers for points!",
                PointCost = 6000
            };

            FakeOffer3 = new Offer
            {
                Id = Guid.Parse("768e9ca1-5b22-4b42-a1ed-9b794388b1e9"),
                Items = new List<Item> { FakeLocation2.Inventory[0] },
                Description = "Buy 2 get one FREE!"
            };

            FakeOffer4 = new Offer
            {
                Id = Guid.Parse("c5650e0f-023e-4684-9bb9-8940dad10463"),
                Items = new List<Item> { FakeLocation2.Inventory[1] },
                Description = "Free Sandwich for points!",
                PointCost = 1500
            };

            FakeLocation1.Offers = new List<Offer>() { FakeOffer1, FakeOffer2 };
            FakeLocation2.Offers = new List<Offer>() { FakeOffer3, FakeOffer4 };



            // Transaction History Inits
            FakeTransaction1 = new Transaction
            {
                Id = Guid.Parse("021c642b-349b-47e6-833c-12bfdfefb479"),
                User = FakeUser1,
                Business = FakeBusiness1,
                Location = FakeLocation1,
                ItemsPurchased = new List<TransactionItem>
                    {
                        new TransactionItem
                        {
                            Id = Guid.Parse("d349bb04-951d-45e3-beca-d1f40d57c249"),
                            ItemId = Guid.Parse("0de50d81-17cc-4ad6-9f15-daf8d748f73f"),
                            NameAtPurchase = "Shampoo",
                            PriceAtPurchase = 8.99M,
                            DescriptionAtPurchase = "Liquid you put in your hair to clean your hair and scalp!",
                            QuantityPurchased = 2
                        }
                    },
                OffersUsed = new List<Offer> { FakeOffer1 },
                TotalSpent = 9.89M,
                PointsGained = 989,
                Timestamp = new DateTime(2026, 3, 15, 12, 0, 0)
            };


            FakeUser1.Transactions = new List<Transaction>() { FakeTransaction1 };
      


            // Notifications Inits
            FakeUser1.Notifications = new List<Notification>
            {
                new Notification
                {
                    Id = Guid.Parse("42893f98-2741-4123-b046-a568e07569fc"),
                    User = FakeUser1,
                    Header = "New Item available at your location!",
                    Message = "Hi {User},\nA new item {newItem} has been added to the inventory of the location you shop at!",
                    Items = new List<Item> { FakeLocation1.Inventory[0] },
                    Timestamp = new DateTime(2026, 3, 10, 12, 0, 0),
                    isRead = false
                }
            };
        }
    }
}