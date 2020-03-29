namespace Yandex.Music.Api.Responses
{
    public class YTrackDownloadInfoResponse
    {
        public string Codec { get; set; }
        public int BitrateInKbps { get; set; }
        public string DownloadInfoUrl { get; set; }
        public bool Gain { get; set; }
        public bool Preview { get; set; }
        public bool Direct { get; set; }
    }
}