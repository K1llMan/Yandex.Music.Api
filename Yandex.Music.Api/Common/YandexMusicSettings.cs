using System;
using System.Security.Cryptography;
using System.Text;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.Common
{
    public class YandexMusicSettings
    {
        public YandexMusicSettings()
        {
        }

        public Uri GetPassportURL()
        {
            return new Uri("https://pda-passport.yandex.ru/passport?mode=auth");
        }

        public Uri GetAlbumURL(string albumId)
        {
            return new Uri(
                $"https://music.yandex.ru/handlers/album.jsx?album={albumId}&lang=ru&external-domain=music.yandex.ru&overembed=false");
        }
      
        public Uri GetTrackURL(string trackId)
        {
            return new Uri(
                $"https://music.yandex.ru/handlers/track.jsx?track={trackId}&lang=ru&external-domain=music.yandex.ru&overembed=false");
        }

        public Uri GetListFavoritesURL(string login)
        {
            return new Uri(
                $"https://music.yandex.ru/handlers/library.jsx?owner={login}&filter=tracks&likeFilter=favorite&sort=&dir=&lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.7506943983987266");
        }

        public Uri GetPlaylistDejaVuURL()
        {
            return new Uri(
                $"https://music.yandex.ru/handlers/playlist.jsx?owner=yamusic-dejavu&kinds=57704235&light=true&madeFor=&lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.13048851242872916");
        }

        public Uri GetPlaylistOfDay()
        {
            return new Uri(
                $"https://music.yandex.ru/handlers/playlist.jsx?owner=yamusic-daily&kinds=57151881&light=true&madeFor=&lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.9083773647705418");
        }

        public Uri GetSearchURL(string searchText, YandexSearchType searchType, int page)
        {
            var searchTypeAsString = searchType.ToString();
            var urlSearch = new StringBuilder();
            urlSearch.Append($"https://music.yandex.ru/handlers/music-search.jsx?text={searchText}");
            urlSearch.Append($"&type={searchTypeAsString}");
            urlSearch.Append(
                $"&page={page}&ncrnd=0.7060701951464323&lang=ru&external-domain=music.yandex.ru&overembed=false");

            return new Uri(urlSearch.ToString());
        }

        public Uri GetDownloadTrackInfoURL(string storageDir, string fileName)
        {
            return new Uri($"http://storage.music.yandex.ru/download-info/{storageDir}/{fileName}");
        }

        public Uri GetURLDownloadFile(string storageDir)
        {
            return new Uri($"http://storage.music.yandex.ru/get/{storageDir}/2.xml");
        }
        
        public Uri GetURLDownloadTrack(YTrackResponse track, YandexTrackDownloadInfo downloadInfo)
        {
            var key = ""; //downloadInfo.Path.Substring(1, downloadInfo.Path.Length - 1) + downloadInfo.S;

            using (var md5 = MD5.Create())
            {
                key = GetMdHesh(md5,
                    $"XGRlBW9FXlekgbPrRHuSiA{downloadInfo.Path.Substring(1, downloadInfo.Path.Length - 1)}{downloadInfo.S}");
            }

            var trackDownloadUrl =
                String.Format("http://{0}/get-mp3/{1}/{2}{3}?track-id={4}&region=225&from=service-search",
                    downloadInfo.Host,
                    key,
                    downloadInfo.Ts,
                    downloadInfo.Path,
                    track.Id);

            return new Uri(trackDownloadUrl);
        }

        protected string GetMdHesh(MD5 md5, string str)
        {
            var data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sBuilder = new StringBuilder();

            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
