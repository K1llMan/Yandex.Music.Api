using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Queue
{
    [YApiRequest(WebRequestMethods.Http.Post, "queues/{queueId}/update-position")]
    public class YQueueUpdatePositionBuilder : YRequestBuilder<YResponse<YUpdatedQueue>, (string queueId, int currentIndex, bool isInteractive)>
    {
        public YQueueUpdatePositionBuilder(YandexMusicApi yandex, AuthStorage auth, string device = null) : base(yandex, auth)
        {
            if (device != null)
            {
                Device = device;   
            }
        }
        
        protected override Dictionary<string, string> GetSubstitutions((string queueId, int currentIndex, bool isInteractive) tuple)
        {
            return new Dictionary<string, string> {
                { "queueId", tuple.queueId },
            };
        }
        
        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            headers.Add("X-Yandex-Music-Device", Device);
        }
        
        protected override NameValueCollection GetQueryParams((string queueId, int currentIndex, bool isInteractive) tuple)
        {
            return new NameValueCollection {
                { "currentIndex", tuple.currentIndex.ToString() },
                { "isInteractive", tuple.isInteractive.ToString().ToLower() }
            };
        }
    }
}
