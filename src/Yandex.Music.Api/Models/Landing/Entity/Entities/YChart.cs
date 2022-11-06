namespace Yandex.Music.Api.Models.Landing.Entity.Entities
{
    public class YChart
    {
        public int Position { get; set; }
        public int Listeners { get; set; }
        public int Shift { get; set; }
        public YChartProgress Progress { get; set; }
    }
}