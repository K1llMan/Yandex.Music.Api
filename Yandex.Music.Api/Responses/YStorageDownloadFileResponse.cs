using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YStorageDownloadFileResponse
    {
        public string S { get; set; }
        public string Ts { get; set; }
        public string Path { get; set; }
        public string Host { get; set; }

        public static YStorageDownloadFileResponse FromJson(JToken data)
        {
            return new YStorageDownloadFileResponse
            {
                S = data["s"].ToObject<string>(),
                Ts = data["ts"].ToObject<string>(),
                Path = data["path"].ToObject<string>(),
                Host = data["host"].ToObject<string>(),
            };
        }
    }
}