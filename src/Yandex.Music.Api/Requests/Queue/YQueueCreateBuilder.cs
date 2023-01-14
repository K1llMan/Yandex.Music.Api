using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Queue
{
    [YApiRequest(WebRequestMethods.Http.Post, "queues")]
    public class YQueueCreateBuilder : YRequestBuilder<YResponse<YNewQueue>, YQueue>
    {
        public YQueueCreateBuilder(YandexMusicApi yandex, AuthStorage auth, string device = null) : base(yandex, auth)
        {
            if (device != null)
            {
                Device = device;   
            }
        }

        // Для метода "queues" JSON-значения строкового вида "null" являются недопустимыми, а они необходимы.
        // Поэтому пришлось создать метод GetStringContent.
        // TODO: унифицировать способ формирования контента.
        protected override StringContent GetStringContent(YQueue queue)
        {
            return new StringContent(SerializeJson(queue), Encoding.UTF8, "application/json");
        }
        
        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            // TODO: delete
            Console.WriteLine("---> HEADER: " + Device);
            
            headers.Add("X-Yandex-Music-Device", Device);
        }
    }
}
