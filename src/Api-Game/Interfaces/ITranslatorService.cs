using Api_Game.Configuration;
using System.Threading.Tasks;

namespace Api_Game.Interfaces
{
    public interface ITranslatorService
    {
        TranslatorSettings Settings { get; }

        Task<string> TranslateToSpanishAsync(string words);
    }
}