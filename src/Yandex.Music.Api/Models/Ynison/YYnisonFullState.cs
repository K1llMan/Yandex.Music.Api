namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonFullState
    {
        public YYnisonPlayerState PlayerState { get; set; }
        public YYnisonDevice Device { get; set; }
        public bool IsCurrentlyActive { get; set; }
    }
}
