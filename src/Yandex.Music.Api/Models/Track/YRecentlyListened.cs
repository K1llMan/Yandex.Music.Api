using System.Collections.Generic;
using Yandex.Music.Api.Models.Landing.Entity.Entities.Context;

namespace Yandex.Music.Api.Models.Track
{
    public class YRecentlyListenedContext
    {
        public List<YRecentlyListened> Contexts { get; set; }
    }
    public class YRecentlyListened
    {
        public string Client { get; set; }
        public string Context { get; set; }
        //public string ContextItem { get; set; }
        public List<YListenedTrack> Tracks { get; set; }
    }
}