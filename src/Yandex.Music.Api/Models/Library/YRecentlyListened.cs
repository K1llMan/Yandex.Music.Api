using System.Collections.Generic;
using Yandex.Music.Api.Models.Landing.Entity.Entities.Context;

namespace Yandex.Music.Api.Models.Library
{
    public class YRecentlyListened
    {
        public string Client { get; set; }
        public YPlayContextType Context { get; set; }
        public string ContextItem { get; set; }
        public List<YListenedTrack> Tracks { get; set; }
    }
}