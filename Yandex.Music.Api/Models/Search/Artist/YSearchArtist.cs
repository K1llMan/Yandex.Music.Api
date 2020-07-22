using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Search.Artist
{
    public class YSearchArtist
    {
        #region Свойства

        public bool? Composer { get; set; }
        public YCover Cover { get; set; }
        public List<string> Decomposed { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Various { get; set; }

        #endregion
    }
}