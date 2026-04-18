using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Interfaces
{
    public interface IAIService
    {
        Task<string> GetResponseAsync(string prompt);
    }
}
