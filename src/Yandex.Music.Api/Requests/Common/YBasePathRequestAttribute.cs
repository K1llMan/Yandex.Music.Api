namespace Yandex.Music.Api.Requests.Common
{
    /// <summary>
    /// Атрибут запроса относительно базового адреса
    /// </summary>
    public class YBasePathRequestAttribute : YRequestAttribute
    {
        #region Поля

        protected string basePath;

        #endregion Поля

        #region Свойства
        public override string Url => GetFullUrl();

        #endregion Свойства

        #region Вспомогательные функции

        private string GetFullUrl()
        {
            return $"{basePath.TrimEnd('/')}/{path.TrimStart('/')}";
        }

        #endregion Вспомогательные функции

        public YBasePathRequestAttribute(string method, string url) : base(method, url)
        {
        }
    }
}