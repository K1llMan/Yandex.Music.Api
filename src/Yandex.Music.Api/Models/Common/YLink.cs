namespace Yandex.Music.Api.Models.Common
{
    public class YLink
    {
        public string Href { get; set; }
        public string Url { get; set; }
        public string ImgUrl { get; set; }
        public string SocialNetwork { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public YLinkType Type { get; set; }
    }
}