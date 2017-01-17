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

        public async Task<string> TranslateToEnglishAsync(string words)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TranslateToSpanishAsync(string words)
        {
            var parameters = new Dictionary<string, string>
            {
                { "q", words },
                { "target", Settings.Routes["Spanish"] },
                { "key", Settings.Routes["SecretKey"] }
            };

            var response = await TranslatorHttpClient.GetAsync<DataTranslate>(Settings.ApiUri, Settings.Headers, parameters);
            return response.Data.Translations.First().TranslatedText;
        }
    }
}
