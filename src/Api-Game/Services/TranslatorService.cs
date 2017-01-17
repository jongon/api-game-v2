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

        public Task<string> TranslateToEnglishAsync(string words)
        {
            throw new NotImplementedException();
        }

        Task<string> ITranslatorService.TranslateToSpanish(string words)
        {
            throw new NotImplementedException();
        }
    }
}
