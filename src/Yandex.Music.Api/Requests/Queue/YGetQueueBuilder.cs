using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Queue
{
    [YApiRequest(WebRequestMethods.Http.Get, "queues/{queueId}")]
    public class YGetQueueBuilder : YRequestBuilder<YResponse<YQueue>, string>
    {
        public YGetQueueBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(string queueId)
        {
            return new Dictionary<string, string> {
                { "queueId", queueId }
            };
        }
    }
}
