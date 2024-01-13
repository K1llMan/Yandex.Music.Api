namespace Yandex.Music.Api.Models.Radio
{
    public class YStationFeedback
    {
        public YStationFeedbackType Type { get; set; }

        public long Timestamp { get; set; }

        public string From { get; set; }

        public double TotalPlayedSeconds { get; set; }

        public string TrackId { get; set; }
    }
}