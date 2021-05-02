using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Common
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class YProduct
    {
        #region Свойства

        public string ProductId { get; set; }
        public YProductType Type { get; set; }
        public string CommonPeriodDuration { get; set;}
        public int Duration { get; set;}
        public int TrialDuration { get; set;}
        public YPrice Price { get; set; }
        public bool Plus { get; set; }
        public string Feature { get; set; }
        public List<string> Features { get; set; }
        public bool Debug { get; set; }

        #endregion Свойства
    }
}
