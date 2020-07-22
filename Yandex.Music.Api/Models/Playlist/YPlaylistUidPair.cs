namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylistUidPair
    {
        #region Поля

        public override string ToString()
        {
            return $"{Uid}:{Kind}";
        }

        #endregion

        #region Свойства

        public string Kind { get; set; }
        public string Uid { get; set; }

        #endregion
    }
}