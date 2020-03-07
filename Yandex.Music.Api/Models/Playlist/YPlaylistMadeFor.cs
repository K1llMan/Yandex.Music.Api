using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylistMadeFor
    {
        public YOwner UserInfo { get; set; }
        public YMadeForCaseForms MadeFor { get; set; }

        public class YMadeForCaseForms
        {
            public string Nominative { get; set; }
            public string Genitive { get; set; }
            public string Dative { get; set; }
            public string Accusative { get; set; }
            public string Instrumental { get; set; }
            public string Prepositional { get; set; }
        }
    }
}