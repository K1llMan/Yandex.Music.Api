using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Requests
{
    public enum YHeader
    {
        Accept,
        AcceptCharset,
        AcceptEncoding,
        AcceptLanguage,
        AccessControlAllowMethods,
        ContentType,
        ContentLength,
        SecFetchDest,
        SecFetchMode,
        SecFetchSite,
        XCurrentUID,
        XRequestedWith,
        XRetpathY,
        Origin,
        Referer
    }

    public static class YRequestHeaders
    {
        #region Вспомогательные функции

        private static KeyValuePair<string, string> FormHeader(YHeader header, string value)
        {
            return new KeyValuePair<string, string>(header.ToString().SplitByCapitalLetter("-"), value);
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public static KeyValuePair<string, string> Get(YHeader header, AuthStorage storage)
        {
            string value = string.Empty;
            switch (header) {
                case YHeader.Accept:
                    value = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
                    break;
                case YHeader.AcceptCharset:
                    value = "utf-8";
                    break;
                case YHeader.AcceptEncoding:
                    value = "gzip, deflate, br";
                    break;
                case YHeader.AcceptLanguage:
                    value = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
                    break;
                case YHeader.AccessControlAllowMethods:
                    value = "[POST]";
                    break;
                case YHeader.ContentType:
                    value = "application/json; charset=utf-8";
                    break;
                case YHeader.Origin:
                    value = "https://music.yandex.ru";
                    break;
                case YHeader.Referer:
                    value = $"https://music.yandex.ru/users/{storage.User.Login}/playlists";
                    break;
                case YHeader.SecFetchDest:
                    value = "empty";
                    break;
                case YHeader.SecFetchMode:
                    value = "cors";
                    break;
                case YHeader.SecFetchSite:
                    value = "same-origin";
                    break;
                case YHeader.XRequestedWith:
                    value = "XMLHttpRequest";
                    break;
                case YHeader.XRetpathY:
                    value = $"https://music.yandex.ru/users/{storage.User.Login}/playlists";
                    break;
            }

            return FormHeader(header, value);
        }

        public static KeyValuePair<string, string> Get(YHeader header, string value)
        {
            return FormHeader(header, value);
        }

        #endregion Основные функции
    }
}