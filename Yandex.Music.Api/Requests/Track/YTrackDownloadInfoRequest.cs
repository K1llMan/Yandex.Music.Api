using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YTrackDownloadInfoRequest : YRequest
    {
        public YTrackDownloadInfoRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string trackKey)
        {
            var time = storage.Context.GetTimeInterval().ToString();
            var url =
                $"https://music.yandex.ru/api/v2.1/handlers/track/{trackKey}/web-own_tracks-track-track-main/download/m?hq=0&external-domain=music.yandex.ru&overembed=no&__t={time}";

            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.Accept, storage),
                YRequestHeaders.Get(YHeader.AcceptLanguage, storage),
                YRequestHeaders.Get(YHeader.Origin, storage),
                YRequestHeaders.Get(YHeader.Referer, storage),
                YRequestHeaders.Get(YHeader.SecFetchMode, storage),
                YRequestHeaders.Get(YHeader.SecFetchSite, storage),
                YRequestHeaders.Get(YHeader.XCurrentUID, storage),
                YRequestHeaders.Get(YHeader.XRequestedWith, storage),
                YRequestHeaders.Get(YHeader.XRetpathY, storage)
            };

            FormRequest(url, headers: headers);

            return this;
        }
    }
}