using Api_Game.Configuration;
using Api_Game.Interfaces;

namespace Api_Game.Services
{
    public class ClasificationTableService : IClasificationTableService
    {
        public ImageSettings Settings { get; }

        public ClasificationTableService(ImageSettings settings)
        {
            Settings = settings;
        }
    }
}