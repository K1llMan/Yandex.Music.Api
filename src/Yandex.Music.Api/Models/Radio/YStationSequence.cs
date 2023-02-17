using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Radio
{
    public class YStationSequence
    {
        public string BatchId { get; set; }
        public YStationId Id { get; set; }
        public bool Pumpkin { get; set; }
        public string RadioSessionId { get; set; }
        public List<YSequenceItem> Sequence { get; set; }
    }
}