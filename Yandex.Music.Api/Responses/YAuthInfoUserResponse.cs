namespace Yandex.Music.Api.Responses
{
    public class YAuthInfoUserResponse
    {
        public YandexAuthUser User { get; set; }
        public string Experiments { get; set; }

        public class YandexAuthUser
        {
            public string Sign { get; set; }
            public string Sk { get; set; }
            public bool Premium { get; set; }
            public YandexAuthPlus Plus { get; set; }
            public long SubeditorLevel { get; set; }
            public bool Subeditor { get; set; }
            public bool IsMobileUser { get; set; }
            public YandexAuthSubscription Subscription { get; set; }
            public bool AdDisableable { get; set; }
            public bool IsPremium { get; set; }
            public bool _statusFetched { get; set; }
            public string DeviceId { get; set; }
            public bool OnlyDeviceId { get; set; }
            public string KpOttSubscription { get; set; }
            public bool HavePlus { get; set; }
            public bool HasAvatar { get; set; }
            public string SignUpMethod { get; set; }
            public bool IsHosted { get; set; }
            public bool IsYandex { get; set; }
            public string ContactPhone { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Name { get; set; }
            public string Login { get; set; }
            public string Uid { get; set; }
            public YandexAuthSettings Settings { get; set; }
            public bool HasEmail { get; set; }

            public class YandexAuthSettings
            {
                public string Uid { get; set; }
                public bool LastFmScrobblingEnabled { get; set; }
                public bool FacebookScrobblingEnabled { get; set; }
                public bool ShuffleEnabled { get; set; }
                public bool AddNewTrackOnPlaylistTop { get; set; }
                public int VolumePercents { get; set; }
                public string UserMusicVisibility { get; set; }
                public string UserSocialVisibility { get; set; }
                public bool AdsDisabled { get; set; }
                public string Modified { get; set; }
                public bool RbtDisabled { get; set; }
                public string Theme { get; set; }
                public bool PromosDisabled { get; set; }
                public bool AutoPlayRadio { get; set; }
            }

            public class YandexAuthSubscriptionNonAutoRenewable
            {
                public string Start { get; set; }
                public string End { get; set; }
            }

            public class YandexAuthSubscription
            {
                public YandexAuthSubscriptionNonAutoRenewable NonAutoRenewable { get; set; }
                public bool CanStartTrial { get; set; }
                public bool Mcdonalds { get; set; }
            }

            public class YandexAuthPlus
            {
                public bool HasPlus { get; set; }
                public bool IsTutorialCompleted { get; set; }
                public bool Migrated { get; set; }
            }
        }
    }
}