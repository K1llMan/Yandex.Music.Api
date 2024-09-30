using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonPlayerQueue
    {
        public int CurrentPlayableIndex { get; set; } = -1;

        public string EntityId { get; set; }

        #warning нужен enum
        public string EntityType { get; set; } = "VARIOUS";

        #warning нужен enum?
        public string EntityContext { get; set; } = "BASED_ON_ENTITY_BY_DEFAULT";

        public YYnisonQueueOptions Options { get; set; } = new();

        public List<YYnisonPlayableItem> PlayableList { get; set; } = new();

        public string FromOptional { get; set; }

        public YYnisonVersion Version { get; set; }
    }
}