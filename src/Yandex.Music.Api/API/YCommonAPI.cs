namespace Yandex.Music.Api.API
{
    /// <summary>
    /// Родительский класс для ветки API
    /// </summary>
    public class YCommonAPI
    {
        #region Поля

        protected YandexMusicApi api;

        #endregion Поля

        #region Основные функции

        public YCommonAPI(YandexMusicApi yandex)
        {
            api = yandex;
        }

        #endregion Основные функции
    }
}
