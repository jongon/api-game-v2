using System.Collections.Generic;
using Api_Game.Configuration;
using Api_Game.Models;

namespace Api_Game.Interfaces
{
    public interface IClasificationTableService
    {
        IEnumerable<TcseSettings> Settings { get; }

        Tcse ConvertToTcse(Esrb esrb);
    }
}