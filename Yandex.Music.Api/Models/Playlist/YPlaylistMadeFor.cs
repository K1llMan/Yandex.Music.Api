using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylistMadeFor
    {
        #region Свойства

        public YMadeForCaseForms MadeFor { get; set; }
        public YOwner UserInfo { get; set; }

        #endregion

        public class YMadeForCaseForms
        {
            #region Свойства

            public string Accusative { get; set; }
            public string Dative { get; set; }
            public string Genitive { get; set; }
            public string Instrumental { get; set; }
            public string Nominative { get; set; }
            public string Prepositional { get; set; }

            #endregion
        }
    }
}