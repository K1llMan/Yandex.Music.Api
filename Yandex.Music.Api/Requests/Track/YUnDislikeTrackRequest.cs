using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YUnDislikeTrackRequest : YRequest
    {
        public YUnDislikeTrackRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string trackKey)
        {
            string time = storage.Context.GetTimeInterval().ToString();
            var trackPair = trackKey.Split(':');
            var trackId = trackPair.FirstOrDefault();
            var albumId = trackPair.LastOrDefault();

            Dictionary<string, string> body = new Dictionary<string, string> {
                {"timestamp", time },
                {"from", "web-radio-user-main"},
                {"batchId", "undefined"},
                {"trackId", trackId},
                {"albumId", albumId},
                {"totalPlayed", "0.1"},
                {"sign", storage.User.Sign},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "no"}
            };

            var url = $"https://music.yandex.ru/api/v2.1/handlers/radio/radio/history/feedback/undislike/{trackKey}?__t={time}";

            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.Accept, storage),
                YRequestHeaders.Get(YHeader.AcceptCharset, storage),
                YRequestHeaders.Get(YHeader.AcceptEncoding, "utf-8"),
                YRequestHeaders.Get(YHeader.AcceptLanguage, storage),
                YRequestHeaders.Get(YHeader.AccessControlAllowMethods, storage),
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded; charset=UTF-8"),
                YRequestHeaders.Get(YHeader.Origin, storage),
                YRequestHeaders.Get(YHeader.Referer, storage),
                YRequestHeaders.Get(YHeader.SecFetchMode, storage),
                YRequestHeaders.Get(YHeader.SecFetchSite, storage),
                YRequestHeaders.Get(YHeader.XCurrentUID, storage),
                YRequestHeaders.Get(YHeader.XRequestedWith, storage),
                YRequestHeaders.Get(YHeader.XRetpathY, storage),
            };

            FormRequest(url, body: GetQueryString(body), headers: headers);

            return this;
        }
    }
}