using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Game.Configuration
{
    public class StorageBlobSettings
    {
        public string Url { get; set; }

        public IEnumerable<ImageSettings> Images { get; set; }
    }
}
