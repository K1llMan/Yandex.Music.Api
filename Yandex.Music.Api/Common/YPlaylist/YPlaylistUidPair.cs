namespace Yandex.Music.Api.Common.YPlaylist
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
