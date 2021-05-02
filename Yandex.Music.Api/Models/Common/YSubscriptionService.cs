using System;

namespace Yandex.Music.Api.Models.Common
{
    /// <summary>
    /// Сервис подписки
    /// </summary>
    public class YSubscriptionService
    {
        #region Свойства

        public DateTime Expires { get; set; }
        public string Vendor { get; set; }
        public string VendorHelpUrl { get; set; }
        public string ProductId { get; set; }
        public YProduct Product { get; set; }
        public decimal OrderId { get; set; }
        public bool Finished { get; set; }

        #endregion Свойства
    }
}
