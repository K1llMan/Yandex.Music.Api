namespace Yandex.Music.Api.Models.Queue
{
    public class YQueueItem
    {
        public string Id { get; set; }
        public YContext Context { get; set; }
        public YContext InitialContext { get; set; }
        public string Modified { get; set; }
    }
}
