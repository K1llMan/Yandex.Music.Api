using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Radio.Restriction
{
    public class YRestrictionEnum: YRestriction
    {
        public List<YRestrictionValue<string>> PossibleValues { get; set; }
    }
}
