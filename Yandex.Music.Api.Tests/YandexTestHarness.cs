using System;
using System.IO;

using Newtonsoft.Json;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.YPlaylist;
using Yandex.Music.Api.Common.YTrack;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.Tests
{
    public class YandexTestHarness : IDisposable
    {
        public YandexTestHarness()
        {
            AppSettings = GetAppSettings();

            Storage = new YAuthStorage();

            API = new YandexMusicApi();
        }

        public void Dispose()
        {
        }

        #region Вспомогательные функции

        private AppSettings GetAppSettings()
        {
            string fileSource;

            using (var stream = new FileStream("appsettings.json", FileMode.Open)) {
                using (var reader = new StreamReader(stream)) {
                    fileSource = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<AppSettings>(fileSource);
        }

        #endregion Вспомогательные функции

        #region Свойства

        public AppSettings AppSettings { get; set; }

        public YAuthStorage Storage { get; set; }

        public YandexMusicApi API { get; set; }

        #region Поля для сохранения тестовых данных

        public YAlbumResponse Album { get; set; }

        public YArtistResponse Artist { get; set; }

        public YPlaylist Playlist { get; set; }

        public YTrack Track { get; set; }

        public YPlaylist CreatedPlaylist { get; set; }

        #endregion Поля для сохранения тестовых данных

        #endregion Свойства
    }
}