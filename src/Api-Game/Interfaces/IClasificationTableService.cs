using Api_Game.Configuration;
using Api_Game.Models;
using System.Collections.Generic;

namespace Api_Game.Interfaces
{
    public interface IClasificationTableService
    {
        IEnumerable<ClasificationSettings> TcseSettings { get; }

        IEnumerable<ClasificationSettings> EsrbSettings { get; }
        
        Tcse ConvertToTcse(Esrb esrb);
    }
}