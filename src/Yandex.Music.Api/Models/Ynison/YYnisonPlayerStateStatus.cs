namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonPlayerStateStatus
    {
        public decimal DurationMs { get; set; }
        public bool Paused { get; set; } = true;
        public decimal PlaybackSpeed { get; set; } = 1;
        public decimal ProgressMs { get; set; }
        public YYnisonVersion Version { get; set; }
    }
}
