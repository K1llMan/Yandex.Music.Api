using System;
using System.IO;

using Newtonsoft.Json;

using Yandex.Music.Api.Common.Debug;
using Yandex.Music.Api.Common.Debug.Writer;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Tests
{
    public class YandexTestHarness : IDisposable
    {
        public YandexTestHarness()
        {
            AppSettings = GetAppSettings();

            IDebugWriter writer = new DefaultDebugWriter("responses", "log.txt");

            Client = new YandexMusicClient(new DebugSettings(writer) {
                ClearDirectory = true
            });
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

        public YandexMusicClient Client { get; set; }

        #region Поля для сохранения тестовых данных

        public YAlbum Album { get; set; }

        public YArtistBriefInfo Artist { get; set; }

        public YPlaylist Playlist { get; set; }

        public YTrack Track { get; set; }

        public YPlaylist CreatedPlaylist { get; set; }

        public YStation Station { get; set; }
        
        public YNewQueue NewQueue { get; set; }

        #endregion Поля для сохранения тестовых данных

        #endregion Свойства
    }
}