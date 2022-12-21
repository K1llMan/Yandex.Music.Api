using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Landing
{
    public class YLandingHeaderSpecialBlock
    {
        public string AnimationUrl { get; set; }
        public string BgImageUrl { get; set; }
        public YLandingHeaderButton Button { get; set; }
        public string DoodleImageUrl { get; set; }
        public string EndGradientColor { get; set; }
        public string StartGradientColor { get; set; }
        public string Title { get; set; }
    }
}