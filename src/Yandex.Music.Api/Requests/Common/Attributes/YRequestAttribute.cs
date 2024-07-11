using System;

namespace Yandex.Music.Api.Requests.Common.Attributes
{
    /// <summary>
    /// Атрибут запроса без привязки к базовому адресу
    /// </summary>
#if NET7_0_OR_GREATER
#pragma warning disable CA1018 // Пометить атрибуты как AttributeUsageAttribute
#endif
    public class YRequestAttribute : Attribute
#if NET7_0_OR_GREATER
#pragma warning restore CA1018 // Пометить атрибуты как AttributeUsageAttribute
#endif
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
