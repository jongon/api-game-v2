using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Configuration;

namespace Api_Game.Interfaces
{
    public interface ITranslatorService
    {
        TranslatorSettings Settings { get; }

        Task<string> TranslateToEnglishAsync(string words);

        Task<string> TranslateToSpanishAsync(string words);
    }
}
