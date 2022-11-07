namespace Yandex.Music.Api.Models.Common
{
    public class YLyrics
    {
        public string Id { get; set; }
        public string Lyrics { get; set; }
        public string FullLyrics { get; set; }
        public bool HasRights { get; set; }
        public bool ShowTranslation { get; set; }
        public string TextLanguage { get; set; }
    }
}