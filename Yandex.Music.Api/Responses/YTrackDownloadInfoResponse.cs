using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YTrackDownloadInfoResponse
    {
        public string Codec { get; set; }
        public int Bitrate { get; set; }
        public string Src { get; set; }
        public bool Gain { get; set; }
        public bool Preview { get; set; }

        public static YTrackDownloadInfoResponse FromJson(JToken data)
        {
            return new YTrackDownloadInfoResponse
            {
                Codec = data["codec"].ToObject<string>(),
                Bitrate = data["bitrate"].ToObject<int>(),
                Src = data["src"].ToObject<string>(),
                Gain = data["gain"].ToObject<bool>(),
                Preview = data["preview"].ToObject<bool>(),
            };
        }
    }
}