namespace Yandex.Music.Api.Models.Common
{
    public class YLink
    {
        #region Свойства

        public string Href { get; set; }
        public string SocialNetwork { get; set; }
        public string Title { get; set; }
        public YLinkType Type { get; set; }

        #endregion
    }
}