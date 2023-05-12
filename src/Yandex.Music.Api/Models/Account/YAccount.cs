using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Account
{
    public class YAccount
    {
        public bool Child { get; set; }
        public string Birthday { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public bool HostedUser { get; set; }
        public string Login { get; set; }
        public bool NonOwnerFamilyMember { get; set; }
        public DateTime Now { get; set; }
        [JsonProperty("passport-phones")] 
        public List<YPhone> PassportPhones { get; set; }
        public int Region { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string SecondName { get; set; }
        public bool ServiceAvailable { get; set; }
        public string Uid { get; set; }
    }
}