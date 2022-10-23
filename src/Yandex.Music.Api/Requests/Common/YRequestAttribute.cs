using System;

namespace Yandex.Music.Api.Requests.Common
{
    /// <summary>
    /// Атрибут запроса без привязки к базовому адресу
    /// </summary>
    public class YRequestAttribute: Attribute
    {
        #region Поля

        protected string path;

        #endregion Поля

        #region Свойства

        public string Method { get; }
        public virtual string Url => path;

        #endregion Свойства

        public YRequestAttribute(string method, string url)
        {
            Method = method;
            path = url;
        }
    }
}