using Yandex.Music.Api.Models.Album;

namespace Yandex.Music.Api.Models.Landing.Entity.Entities.Context
{
    public class YPlayContextAlbum: YPlayContext
    {
        public YAlbum Payload { get; set; }
    }
}