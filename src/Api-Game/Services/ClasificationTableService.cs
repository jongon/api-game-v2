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
        public IEnumerable<TcseSettings> Settings { get; }

        public ClasificationTableService(IEnumerable<TcseSettings> settings)
        {
            Settings = settings;
        }

        public Tcse ConvertToTcse(Esrb esrb)
        {
            TcseEnum tcseRating;

            switch (esrb.Rating)
            {
                case EsrbEnum.E:
                case EsrbEnum.Ec:
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

                case EsrbEnum.Rp:
                    tcseRating = TcseEnum.EC;
                    break;

                default:
                    tcseRating = TcseEnum.EC;
                    break;
            }

            var tcse = FillTableData(tcseRating);

            return tcse;
        }

        private Tcse FillTableData(TcseEnum tcseEnum)
        {
            Func<TcseSettings, TcseEnum, bool> findExpression = (x, y) => x.Id == (int)y;
            TcseSettings setting;

            switch (tcseEnum)
            {
                case TcseEnum.EC:
                    setting = Settings.FirstOrDefault(x => findExpression(x, TcseEnum.EC));
                    return new Tcse
                    {
                        Rating = TcseEnum.EC,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };

                case TcseEnum.TU:
                    setting = Settings.FirstOrDefault(x => findExpression(x, TcseEnum.TU));
                    return new Tcse
                    {
                        Rating = TcseEnum.TU,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };

                case TcseEnum.UA:
                    setting = Settings.FirstOrDefault(x => findExpression(x, TcseEnum.UA));
                    return new Tcse
                    {
                        Rating = TcseEnum.UA,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };

                case TcseEnum.UM:
                    setting = Settings.FirstOrDefault(x => findExpression(x, TcseEnum.UM));
                    return new Tcse
                    {
                        Rating = TcseEnum.UM,
                        Title = setting.Title,
                        Description = setting.Description,
                        Image = setting.Image.Normal,
                        Thumbnail = setting.Image.Thumbnail
                    };

                default:
                    setting = Settings.FirstOrDefault(x => findExpression(x, TcseEnum.EC));
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