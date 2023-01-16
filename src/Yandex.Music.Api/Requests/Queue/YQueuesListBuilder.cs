using System.Net;
using System.Net.Http.Headers;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Queue
{
    [YApiRequest(WebRequestMethods.Http.Get, "queues")]
    public class YQueuesListBuilder : YRequestBuilder<YResponse<YQueueItemsContainer>, string>
    {
        public YQueuesListBuilder(YandexMusicApi yandex, AuthStorage auth, string device = null) : base(yandex, auth)
        {
            if (device != null)
            {
                Device = device;   
            }
        }

        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            headers.Add("X-Yandex-Music-Device", Device);
        }
    }
}
