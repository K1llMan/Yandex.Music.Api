using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Models.Landing.Entity.Entities.Context
{
    public class YPlayContextArtist : YPlayContext
    {
        public YArtist Payload { get; set; }
    }
}