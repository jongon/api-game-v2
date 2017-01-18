using Api_Game.Configuration;
using Api_Game.Models;
using System.Collections.Generic;

namespace Api_Game.Interfaces
{
    public interface IClasificationTableService
    {
        IEnumerable<TcseSettings> Settings { get; }

        Tcse ConvertToTcse(Esrb esrb);
    }
}