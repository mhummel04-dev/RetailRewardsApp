using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Services
{
    public class TransactionService
    {
        FakeDatabaseService FakeDB = new FakeDatabaseService();
        public Transaction GetTransactionById(Guid Id)
        {
            Transaction Transaction = FakeDB.FakeTransactionTable.FirstOrDefault(i => i.Id == Id);
            return Transaction;
        }
    }
}
