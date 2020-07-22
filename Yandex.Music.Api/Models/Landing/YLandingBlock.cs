using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Landing
{
    public class YLandingBlock
    {
        #region Свойства

        public YLandingBlockData data { get; set; }
        public List<YLandingBlockEntity> Entities { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string TypeForFrom { get; set; }

        #endregion
    }
}