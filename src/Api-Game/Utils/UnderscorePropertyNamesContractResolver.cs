﻿using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;

namespace Api_Game.Utils
{
    public class UnderscorePropertyNamesContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, @"(\w)([A-Z])", "$1_$2").ToLower();
        }
    }
}