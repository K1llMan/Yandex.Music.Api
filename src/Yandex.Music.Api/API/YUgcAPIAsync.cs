using System;
using System.IO;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Ugc;
using Yandex.Music.Api.Requests.Ugc;

namespace Yandex.Music.Api.API
{
    public partial class YUgcAPI : YCommonAPI
    {
        public YUgcAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        /// <summary>
        /// Получение ссылки на загрузчик трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист, куда будет загружен трек</param>
        /// <param name="fileName">Название файла для загрузки</param>
        public Task<YUgcUpload> GetUgcUploadLinkAsync(AuthStorage storage, YPlaylist playlist, string fileName)
        {
            return new YUgcGetUploadLinkBuilder(api, storage)
                .Build((playlist, fileName))
                .GetResponseAsync();
        }

        /// <summary>
        /// Загрузка трека из файла
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="uploadLink">Ссылка на балансировщик для загрузки, можно получить из GetUgcUploadLinkAsync</param>
        /// <param name="filePath">Загружаемый файл</param>
        public Task<YResponse<string>> UploadUgcTrackAsync(AuthStorage storage, string uploadLink, string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл для загрузки не существует.", filePath);

            return UploadUgcTrackAsync(storage, uploadLink, File.Open(filePath, FileMode.Open));
        }

        /// <summary>
        /// Загрузка трека из потока
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="uploadLink">Ссылка на балансировщик для загрузки, можно получить из GetUgcUploadLinkAsync</param>
        /// <param name="stream">Поток с данными для загрузки</param>
        public Task<YResponse<string>> UploadUgcTrackAsync(AuthStorage storage, string uploadLink, Stream stream)
        {
            if (stream == null)
                throw new NullReferenceException("Пустая ссылка на поток загрузки.");

            using MemoryStream ms = new();
            stream.CopyTo(ms);

            return UploadUgcTrackAsync(storage, uploadLink, ms.ToArray());
        }

        /// <summary>
        /// Загрузка трека из массива
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="uploadLink">Ссылка на балансировщик для загрузки, можно получить из GetUgcUploadLinkAsync</param>
        /// <param name="file">Загружаемый трек в виде массив байтов</param>
        public Task<YResponse<string>> UploadUgcTrackAsync(AuthStorage storage, string uploadLink, byte[] file)
        {
            return new YUgcUploadBuilder(api, storage)
                .Build((uploadLink, file))
                .GetResponseAsync();
        }
    }
}