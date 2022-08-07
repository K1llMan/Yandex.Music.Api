using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Radio
{
    public class YStation : YBaseModel
    {
        public YAdParams AdParams { get; set; }
        public string CustomName { get; set; }
        public YStationData Data { get; set; }
        public string Explanation { get; set; }
        public List<YPrerolls> Prerolls { get; set; }
        public string RupTitle { get; set; }
        public string RupDescription { get; set; }
        public YStationSettings Settings { get; set; }
        public YStationSettings2 Settings2 { get; set; }
        public YStationDescription Station { get; set; }
    }
}