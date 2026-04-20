using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Microsoft.SemanticKernel;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Plugins
{
    public class UserHistoryPlugin
    {
        private readonly SessionService _sessionService;
        public UserHistoryPlugin(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [KernelFunction("get_user_info")]
        [Description("Gets basic profile info for the user like name and current points.")]
        public string GetUserInfo()
        {
            User user = _sessionService.LoggedInUser;
            string userInfo = "";
            userInfo += "User: " + user.FirstName + " " + user.LastName + "\n";
            userInfo += "Birthday: " + user.Birthday.ToString() + "\n";
            userInfo += "Points: " + user.Points + "\n";
            userInfo += "Registered Location: " + _sessionService.RegisteredLocation.Title + "\n";

            return userInfo;
        }

        [KernelFunction("get_recent_purchases")]
        [Description("Returns a list of the user's recent purchases from the last 15 days.")]
        public string GetRecentPurchases()
        {
            var sb = new StringBuilder();
            sb.AppendLine("User Transaction History (Last 15 days):");

            foreach (var trans in _sessionService.LoggedInUser.Transactions)
            {
                string itemsList = string.Join(", ", trans.ItemsPurchased.Select(i => i.NameAtPurchase));

                string offersList = trans.OffersUsed != null && trans.OffersUsed.Any()
                    ? string.Join(", ", trans.OffersUsed.Select(o => o.Description))
                    : "None";

                sb.AppendLine("---");
                sb.AppendLine($"Timestamp: {trans.Timestamp:yyyy-MM-dd HH:mm}");
                sb.AppendLine($"Business: {trans.Business.Name}");
                sb.AppendLine($"Location: {trans.Location.Title}");
                sb.AppendLine($"Items: {itemsList}");
                sb.AppendLine($"Total Spent: ${trans.TotalSpent:F2}");
                sb.AppendLine($"Offers Used: {offersList}");
                sb.AppendLine($"Points Used: {trans.PointsUsed}");
            }

            return sb.ToString();
        }
    }
}
