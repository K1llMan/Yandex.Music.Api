﻿using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Landing.Entity
{
    public enum YLandingEntityType
    {
        Album,
        [EnumMember(Value = "chart-item")]
        ChartItem,
        [EnumMember(Value = "personal-playlist")]
        PersonalPlaylist,
        [EnumMember(Value = "play-context")]
        PlayContext,
        Playlist,
        Podcast,
        Promotion,
        Category,
        Station,
        [EnumMember(Value = "menu-item-album")]
        MenuItemAlbum,
        [EnumMember(Value = "menu-item-playlist")]
        MenuItemPlaylist,
        [EnumMember(Value = "client-widget")]
        ClientWidget
    }
}