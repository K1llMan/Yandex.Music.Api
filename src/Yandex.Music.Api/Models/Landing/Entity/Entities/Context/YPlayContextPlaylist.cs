using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Models.Landing.Entity.Entities.Context
{
    public class YPlayContextPlaylist : YPlayContext
    {
        public YPlaylist Payload { get; set; }
    }
}