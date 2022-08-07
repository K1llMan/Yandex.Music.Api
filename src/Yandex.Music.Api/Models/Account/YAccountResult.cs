using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Account
{
    public class YAccountResult
    {
        public YAccount Account { get; set; }
        public string DefaultEmail { get; set; }
        public YMasterHub MasterHub { get; set; }
        public YPermissions Permissions { get; set; }
        public YPlus Plus { get; set; }
        public bool PretrialActive { get; set; }
        public bool SubEditor { get; set; }
        public int SubEditorLevel { get; set; }
        public YSubscription Subscription { get; set; }
        public YBar BarBelow { get; set; }
        // Повторяющееся свойство с другим названием
        [JsonProperty("bar-below")]
        private YBar BarBelow2 {
            set => BarBelow = value;
        }
        public string Userhash { get; set; }
    }
}