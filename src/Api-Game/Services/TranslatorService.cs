using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Configuration;
using Api_Game.Interfaces;

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
            throw new NotImplementedException();
        }
    }
}
