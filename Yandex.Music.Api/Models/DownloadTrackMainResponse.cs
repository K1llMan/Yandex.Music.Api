namespace Yandex.Music.Api.Models
{
    public class DownloadTrackMainResponse
    {
        public string Codec { get; set; }
        public int Bitrate { get; set; }
        public string Src { get; set; }
        public bool Gain { get; set; }
        public bool Preview { get; set; }
    }
}