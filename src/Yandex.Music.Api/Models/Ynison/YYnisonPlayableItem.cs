namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonPlayableItem
    {
        public string AlbumIdOptional { get; set; }

        #warning нужен enum
        public string From { get; set; }
        
        public string PlayableId { get; set; }

        public YYnisonPlayableItemType PlayableType { get; set; }

        public string Title { get; set; }

        public YYnisonTrackInfo TrackInfo { get; set; }
    }
}