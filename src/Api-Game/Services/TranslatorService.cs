using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Configuration;
using Api_Game.Interfaces;
using Api_Game.Utils;
using Api_Game.Models;

namespace Api_Game.Services
{
    public class TranslatorService : ITranslatorService
    {
        public TranslatorSettings Settings { get; }

        public TranslatorService(TranslatorSettings settings)
        {
            Settings = settings;
        }

        public async Task<string> TranslateToSpanishAsync(string words)
        {
            var parameters = new Dictionary<string, string>
            {
                { "q", words },
                { "target", Settings.Parameters["Spanish"] },
                { "key", Settings.Parameters["SecretKey"] }
            };

            var response = await TranslatorHttpClient.GetAsync<DataTranslate>(Settings.ApiUri, parameters);
            return response.Data.Translations.First().TranslatedText;
        }
    }
}
