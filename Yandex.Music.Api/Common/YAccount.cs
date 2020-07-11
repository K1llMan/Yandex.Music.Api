using System;

namespace Yandex.Music.Api.Common
{
    public class YAccount
    {
        public string Uid { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public DateTime Now { get; set; }
        public bool ServiceAvailable { get; set; }
    }
}
