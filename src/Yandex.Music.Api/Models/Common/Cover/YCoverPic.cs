namespace Yandex.Music.Api.Models.Common.Cover
{
    public class YCoverPic : YCover
    {
        public bool Custom { get; set; }
        public string Dir { get; set; }
        public bool IsCustom { get; set; }
        public string Uri { get; set; }
        public string Version { get; set; }
    }
}