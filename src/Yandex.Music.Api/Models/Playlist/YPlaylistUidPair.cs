namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylistUidPair
    {
        public string Kind { get; set; }
        public string Uid { get; set; }

        public override string ToString()
        {
            return $"{Uid}:{Kind}";
        }
    }
}