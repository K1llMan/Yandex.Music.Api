using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Common
{
    public class YProfile
    {
        #region Свойства

        public List<string> Addresses { get; set; }
        public string Provider { get; set; }

        #endregion
    }
}