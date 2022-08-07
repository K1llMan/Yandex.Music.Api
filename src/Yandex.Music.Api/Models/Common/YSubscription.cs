using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Common
{
    public class YSubscription
    {
        public List<YSubscriptionService> AutoRenewable { get; set; }
        public bool CanStartTrial { get; set; }
        public bool HadAnySubscription { get; set; }
        public bool McDonalds { get; set; }
        public YPeriod NonAutoRenewable { get; set; }
        public YReminder NonAutoRenewableRemainder { get; set; }
    }
}