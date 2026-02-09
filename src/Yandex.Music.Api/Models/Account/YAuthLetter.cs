using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthLetter : YAuthBase
    {
        public List<string> Code { get; set; }

        public string Id { get; set; }
    }
}
