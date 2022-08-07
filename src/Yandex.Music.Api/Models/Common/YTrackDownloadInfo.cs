namespace Yandex.Music.Api.Models.Common
{
    public class YTrackDownloadInfo
    {
        public int BitrateInKbps { get; set; }
        public string Codec { get; set; }
        public bool Direct { get; set; }
        public string DownloadInfoUrl { get; set; }
        public bool Gain { get; set; }
        public bool Preview { get; set; }
    }
}