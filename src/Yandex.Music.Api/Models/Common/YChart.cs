using Yandex.Music.Api.Models.Landing.Entity.Entities;

namespace Yandex.Music.Api.Models.Common
{
    public class YChart
    {
        public int Position { get; set; }
        public int Listeners { get; set; }
        public int Shift { get; set; }
        public YChartProgress Progress { get; set; }
    }
}