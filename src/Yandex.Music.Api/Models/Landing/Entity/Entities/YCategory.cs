namespace Yandex.Music.Api.Models.Landing.Entity.Entities
{
    public class YCategory: YBlockEntity
    {
        public string BackgroundImageUri { get; set; }
        public string CategoryId { get; set; }
        public bool HasBackgroundImageText { get; set; }
        public string Url { get; set; }
        public string UrlScheme { get; set; }
        public string VoiceTitle { get; set; }
        public string TextColor { get; set; }
        public string TextBackgroundColor { get; set; }
        public string Title { get; set; }

    }
}
