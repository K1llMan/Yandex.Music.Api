using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Common
{
    /// <summary>
    /// Модель ответа от API
    /// </summary>
    public class YResponse<T>
    {
        public YInvocationInfo InvocationInfo { get; set; }

        public T Result { get; set; }

        public YPager Pager { get; set; }
    }
}