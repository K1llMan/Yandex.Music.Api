using System;

namespace Yandex.Music.Api.Models.Ynison.Messages
{
    public class YYnisonErrorMessage: Exception
    {
        public YYnisonError Error { get; set; }
    }
}