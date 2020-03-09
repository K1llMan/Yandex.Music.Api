using System;
using System.IO;

using Newtonsoft.Json;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Tests
{
    public class YandexTestHarness : IDisposable
    {
        public YandexTestHarness()
        {
            Console.WriteLine("Created");
            AppSettings = GetAppSettings();

            Storage = new YAuthStorage(AppSettings.Login, AppSettings.Password);
            StorageEncrypted = new YAuthStorage(AppSettings.Login, AppSettings.Password, YAuthStorageEncryption.Rijndael);

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

        public YAuthStorage StorageEncrypted { get; set; }

        public YandexMusicApi API { get; set; }

        #endregion Свойства
    }
}