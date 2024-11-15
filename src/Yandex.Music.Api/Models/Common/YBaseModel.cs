using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Common
{
    public class YBaseModel
    {
        [JsonIgnore]
        public YExecutionContext Context { get; set; }
    }
}
