using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Account
{
    public class YBar
    {
        public string AlertId { get; set; }
        public string Text { get; set; }
        public string BgColor { get; set; }
        public string TextColor { get; set; }
        public string AlertType { get; set; }
        public YButton Button { get; set; }
        public bool CloseButton { get; set; }
        public YStyles CloseButtonStyles { get; set; }
    }
}
