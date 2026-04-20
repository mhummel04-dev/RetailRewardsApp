using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.Google;
using RetailRewardsApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetailRewardsApp.Core.Services
{
    public class GeminiService : IAIService
    {
        private readonly Kernel _kernel;

        public GeminiService(Kernel kernel)
        {
            _kernel = kernel;
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            try
            {
                var settings = new GeminiPromptExecutionSettings
                {
                    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                };

                var result = await _kernel.InvokePromptAsync(prompt, new KernelArguments(settings));
                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"AI Error: {ex.Message}";
            }
        }
    }
}
