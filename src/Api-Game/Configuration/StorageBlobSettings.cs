﻿using System.Collections.Generic;

namespace Api_Game.Configuration
{
    public class StorageBlobSettings
    {
        public string Url { get; set; }

        public IEnumerable<ImageSettings> Images { get; set; }
    }
}