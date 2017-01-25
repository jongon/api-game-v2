using Api_Game.Configuration;
using Api_Game.Enums;
using Api_Game.Interfaces;
using Api_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_Game.Services
{
    public class ClasificationTableService : IClasificationTableService
    {
        public IEnumerable<ClasificationSettings> TcseSettings { get; }

        public IEnumerable<ClasificationSettings> EsrbSettings { get; }

        public ClasificationTableService(
            IEnumerable<ClasificationSettings> tcseSettings,
            IEnumerable<ClasificationSettings> esrbSettings)
        {
            TcseSettings = tcseSettings;
            EsrbSettings = esrbSettings;
        }

        public Tcse ConvertToTcse(Esrb esrb)
        {
            TcseEnum tcseRating;

            switch (esrb.Rating)
            {
                case EsrbEnum.E:
                case EsrbEnum.EC:
                case EsrbEnum.E10:
                    tcseRating = TcseEnum.TU;
                    break;

                case EsrbEnum.T:
                    tcseRating = TcseEnum.UA;
                    break;

                case EsrbEnum.M:
                case EsrbEnum.AO:
                    tcseRating = TcseEnum.UM;
                    break;

                case EsrbEnum.RP:
                    tcseRating = TcseEnum.EC;
                    break;

                default:
                    tcseRating = TcseEnum.NI;
                    break;
            }

            var tcse = FillTcseData(tcseRating);

            return tcse;
        }

        public Esrb ConvertToEsrb(Esrb esrb)
        {
            return FillEsrbData(esrb.Rating);
        }

        private Esrb FillEsrbData(EsrbEnum esrbEnum)
        {
            Func<ClasificationSettings, EsrbEnum, bool> findExpression = (x, y) => x.Id == (int)y;
            ClasificationSettings setting;

            switch (esrbEnum)
            {
                case EsrbEnum.RP:
                    setting = EsrbSettings.First(x => findExpression(x, EsrbEnum.RP));
                    return new Esrb
                    {
                        Rating = EsrbEnum.RP,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal
                    };

                case EsrbEnum.EC:
                    setting = EsrbSettings.First(x => findExpression(x, EsrbEnum.EC));
                    return new Esrb
                    {
                        Rating = EsrbEnum.EC,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal
                    };

                case EsrbEnum.E:
                    setting = EsrbSettings.First(x => findExpression(x, EsrbEnum.E));
                    return new Esrb
                    {
                        Rating = EsrbEnum.E,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal
                    };

                case EsrbEnum.E10:
                    setting = EsrbSettings.First(x => findExpression(x, EsrbEnum.E10));
                    return new Esrb
                    {
                        Rating = EsrbEnum.E10,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal
                    };

                case EsrbEnum.T:
                    setting = EsrbSettings.First(x => findExpression(x, EsrbEnum.T));
                    return new Esrb
                    {
                        Rating = EsrbEnum.T,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal
                    };

                case EsrbEnum.M:
                    setting = EsrbSettings.First(x => findExpression(x, EsrbEnum.M));
                    return new Esrb
                    {
                        Rating = EsrbEnum.M,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal
                    };

                case EsrbEnum.AO:
                    setting = EsrbSettings.First(x => findExpression(x, EsrbEnum.AO));
                    return new Esrb
                    {
                        Rating = EsrbEnum.AO,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal
                    };

                default:
                    setting = TcseSettings.First(x => findExpression(x, EsrbEnum.NI));
                    return new Esrb
                    {
                        Rating = EsrbEnum.NI,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };
            }
        }

        private Tcse FillTcseData(TcseEnum tcseEnum)
        {
            Func<ClasificationSettings, TcseEnum, bool> findExpression = (x, y) => x.Id == (int)y;
            ClasificationSettings setting;

            switch (tcseEnum)
            {
                case TcseEnum.EC:
                    setting = TcseSettings.First(x => findExpression(x, TcseEnum.EC));
                    return new Tcse
                    {
                        Rating = TcseEnum.EC,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };

                case TcseEnum.TU:
                    setting = TcseSettings.First(x => findExpression(x, TcseEnum.TU));
                    return new Tcse
                    {
                        Rating = TcseEnum.TU,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };

                case TcseEnum.UA:
                    setting = TcseSettings.First(x => findExpression(x, TcseEnum.UA));
                    return new Tcse
                    {
                        Rating = TcseEnum.UA,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };

                case TcseEnum.UM:
                    setting = TcseSettings.First(x => findExpression(x, TcseEnum.UM));
                    return new Tcse
                    {
                        Rating = TcseEnum.UM,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };

                default:
                    setting = TcseSettings.First(x => findExpression(x, TcseEnum.EC));
                    return new Tcse
                    {
                        Rating = TcseEnum.EC,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };
            }
        }
    }
}