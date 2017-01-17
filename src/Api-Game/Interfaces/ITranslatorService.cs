﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Game.Interfaces
{
    public interface ITranslatorService
    {
        Task<string> TranslateToEnglishAsync(string words);

        Task<string> TranslateToSpanish(string words);
    }
}
