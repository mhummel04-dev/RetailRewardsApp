using System;
using System.Collections.Generic;
using System.Text;
using RetailRewardsApp.Core.Interfaces;
using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;

namespace RetailRewardsApp.Core.Services
{
    public class GeminiService : IAIService
    {
        private readonly Kernel _kernel;

        public GeminiService(IConfiguration config)
        {
            var apiKey = config["Gemini:ApiKey"];

            var builder = Kernel.CreateBuilder();
            builder.AddGoogleAIGeminiChatCompletion(
                modelId: "gemini-2.5-flash",
                apiKey: apiKey);

            _kernel = builder.Build();
        }


        public async Task<string> GetResponseAsync(string prompt)
        {
            try
            {
                var result = await _kernel.InvokePromptAsync(prompt);
                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"AI Error: {ex.Message}";
            }
        }
    }
}
