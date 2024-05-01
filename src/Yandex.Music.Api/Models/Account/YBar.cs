using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Account
{
    public class YBar: YStyle
    {
        public string AlertId { get; set; }
        public string Text { get; set; }
        public string AlertType { get; set; }
        public YButton Button { get; set; }
        public bool CloseButton { get; set; }
        public YCloseButtonStyles CloseButtonStyles { get; set; }
    }
}
