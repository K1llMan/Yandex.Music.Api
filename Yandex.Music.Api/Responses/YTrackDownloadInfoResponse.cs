namespace Yandex.Music.Api.Responses
{
    public class YTrackDownloadInfoResponse
    {
        public string Codec { get; set; }
        public int Bitrate { get; set; }
        public string Src { get; set; }
        public bool Gain { get; set; }
        public bool Preview { get; set; }
    }
}