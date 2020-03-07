using System.Collections.Generic;
using System.Net;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetTrackResponse : YRequest
    {
        public YGetTrackResponse(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string trackId)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                {"track", trackId}
            };

            return GetRequest(YEndpoints.Track, query: query);
        }
    }
}