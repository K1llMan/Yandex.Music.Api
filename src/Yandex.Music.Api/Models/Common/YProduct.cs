using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Common
{
    public class YProduct
    {
        public string CommonPeriodDuration { get; set; }
        public string TrialPeriodDuration { get; set; }
        public bool Debug { get; set; }
        public int Duration { get; set;}
        public bool Family { get; set;}
        public string Feature { get; set; }
        public List<string> Features { get; set; }
        public bool Plus { get; set; }
        public YPrice Price { get; set; }
        public string ProductId { get; set; }
        public int TrialDuration { get; set;}
        public YProductType Type { get; set; }
    }
}
