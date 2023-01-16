using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Tests
{
    public class YandexTestHarness : IDisposable
    {
        public YandexTestHarness()
        {
            AppSettings = GetAppSettings();

            Storage = new AuthStorage(new DebugSettings("responses", "log.txt") {
                ClearDirectory = true
            });

            API = new YandexMusicApi();
        }

        public void Dispose()
        {
        }

        #region Вспомогательные функции

        private AppSettings GetAppSettings()
        {
            using FileStream stream = new("appsettings.json", FileMode.Open);
            using StreamReader reader = new(stream);
            string fileSource = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<AppSettings>(fileSource);
        }

        #endregion Вспомогательные функции

        #region Свойства

        public AppSettings AppSettings { get; set; }

        public AuthStorage Storage { get; set; }

        public YandexMusicApi API { get; set; }

        #region Поля для сохранения тестовых данных

        public YResponse<YAlbum> Album { get; set; }

        public YResponse<YArtistBriefInfo> Artist { get; set; }

        public YPlaylist Playlist { get; set; }

        public YTrack Track { get; set; }

        public YPlaylist CreatedPlaylist { get; set; }
        
        public YNewQueue NewQueue { get; set; }

        public YResponse<List<YStation>> Station {get; set; }

        #endregion Поля для сохранения тестовых данных

        #endregion Свойства
    }
}