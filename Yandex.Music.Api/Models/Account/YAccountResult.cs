using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Account
{
    public class YAccountResult
    {
        #region Свойства

        public YAccount Account { get; set; }
        public string DefaultEmail { get; set; }
        public YPermissions Permissions { get; set; }
        public YPlus Plus { get; set; }
        public bool SubEditor { get; set; }
        public int SubEditorLevel { get; set; }
        public YSubscription Subscription { get; set; }

        #endregion
    }
}