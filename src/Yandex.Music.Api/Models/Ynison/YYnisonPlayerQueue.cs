using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonPlayerQueue
    {
        public int CurrentPlayableIndex { get; set; } = -1;

        public string EntityId { get; set; }

        public YYnisonEntityType EntityType { get; set; } = YYnisonEntityType.Various;

        public YYnisonEntityContext EntityContext { get; set; } = YYnisonEntityContext.BasedOnEntityByDefault;

        public YYnisonQueueOptions Options { get; set; } = new();

        public List<YYnisonPlayableItem> PlayableList { get; set; } = new();
        public YYnisonQueue Queue { get; set; }

        public string FromOptional { get; set; }

        public YYnisonVersion Version { get; set; }
    }
}
