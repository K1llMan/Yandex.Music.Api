using System;
using System.Collections.Generic;

using Yandex.Music.Api.Models.Landing.Entity.Entities;

namespace Yandex.Music.Api.Models.Feed
{
    public class YFeed
    {
        public DateTime NextRevision { get; set; }
        public bool CanGetMoreEvents { get; set; }
        public bool Pumpkin { get; set; }
        public bool IsWizardPassed { get; set; }
        public List<YFeedDay> Days { get; set; }
        public List<YPersonalPlaylist> GeneratedPlaylists { get; set; }
        public List<YHeadline> Headlines { get; set; }
        public DateTime Today { get; set; }
    }
}