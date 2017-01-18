﻿using Api_Game.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_Game.Utils
{
    public static class ConfigurationMerger
    {
        public static IList<TcseSettings> SetClasificationImageUrls(StorageBlobSettings storageSettings, IEnumerable<TcseSettings> tcseSettings)
        {
            var tcseList = tcseSettings as IList<TcseSettings> ?? tcseSettings.ToList();
            var baseUri = new Uri(storageSettings.Url);

            foreach (var tcseSetting in tcseList)
            {
                tcseSetting.Image.Normal =
                    string.IsNullOrWhiteSpace(tcseSetting.Image.Normal) ?
                    tcseSetting.Image.Normal :
                    new Uri(baseUri, tcseSetting.Image.Normal).AbsoluteUri;

                tcseSetting.Image.Thumbnail =
                    string.IsNullOrWhiteSpace(tcseSetting.Image.Thumbnail) ?
                    tcseSetting.Image.Thumbnail :
                    new Uri(baseUri, tcseSetting.Image.Thumbnail).AbsoluteUri;
            }

            return tcseList;
        }
    }
}