using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Landing
{
    public class YChildrenLanding
    {
        public string Title { get; set; }
        public bool RupEnabled { get; set; }
        public List<YLandingBlock> Blocks { get; set; }
    }
}
