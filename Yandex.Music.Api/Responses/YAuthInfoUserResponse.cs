using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YAuthInfoUserResponse
    {
        public YandexAuthUser User { get; set; }
        public string Experiments { get; set; }

        public static YAuthInfoUserResponse FromJson(JToken json)
        {
            var authUserPlus = new YandexAuthUser.YandexAuthPlus
            {
                HasPlus = json["user"]["plus"]["hasPlus"].ToObject<bool>(),
                IsTutorialCompleted = json["user"]["plus"]["isTutorialCompleted"].ToObject<bool>(),
                Migrated = json["user"]["plus"]["migrated"].ToObject<bool>()
            };
            var authUserSubscription = new YandexAuthUser.YandexAuthSubscription
            {
                NonAutoRenewable = new YandexAuthUser.YandexAuthSubscriptionNonAutoRenewable
                {
                    Start = json["user"]["subscription"]["nonAutoRenewable"]["start"].ToObject<string>(),
                    End = json["user"]["subscription"]["nonAutoRenewable"]["end"].ToObject<string>()
                },
                CanStartTrial = json["user"]["subscription"]["canStartTrial"].ToObject<bool>(),
                Mcdonalds = json["user"]["subscription"]["mcdonalds"].ToObject<bool>()
            };
            var authUserSettings = new YandexAuthUser.YandexAuthSettings
            {
                Uid = json["user"]["settings"]["uid"].ToObject<string>(),
                LastFmScrobblingEnabled = json["user"]["settings"]["lastFmScrobblingEnabled"].ToObject<bool>(),
                FacebookScrobblingEnabled = json["user"]["settings"]["facebookScrobblingEnabled"].ToObject<bool>(),
                ShuffleEnabled = json["user"]["settings"]["shuffleEnabled"].ToObject<bool>(),
                AddNewTrackOnPlaylistTop = json["user"]["settings"]["addNewTrackOnPlaylistTop"].ToObject<bool>(),
                VolumePercents = json["user"]["settings"]["volumePercents"].ToObject<int>(),
                UserMusicVisibility = json["user"]["settings"]["userMusicVisibility"].ToObject<string>(),
                UserSocialVisibility = json["user"]["settings"]["userSocialVisibility"].ToObject<string>(),
                AdsDisabled = json["user"]["settings"]["adsDisabled"].ToObject<bool>(),
                Modified = json["user"]["settings"]["modified"].ToObject<string>(),
                RbtDisabled = json["user"]["settings"]["rbtDisabled"].ToObject<bool>(),
                Theme = json["user"]["settings"]["theme"].ToObject<string>(),
                PromosDisabled = json["user"]["settings"]["promosDisabled"].ToObject<bool>(),
                AutoPlayRadio = json["user"]["settings"]["autoPlayRadio"].ToObject<bool>(),
            };

            var authUser = new YandexAuthUser
            {
                Sign = json["user"]["sign"].ToObject<string>(),
                Sk = json["user"]["sk"].ToObject<string>(),
                Premium = json["user"]["premium"].ToObject<bool>(),
                Plus = authUserPlus,
                SubeditorLevel = json["user"]["subeditorLevel"].ToObject<int>(),
                Subeditor = json["user"]["subeditor"].ToObject<bool>(),
                IsMobileUser = json["user"]["isMobileUser"].ToObject<bool>(),
                Subscription = authUserSubscription,
                AdDisableable = json["user"]["adDisableable"].ToObject<bool>(),
                IsPremium = json["user"]["isPremium"].ToObject<bool>(),
                _statusFetched = json["user"]["_statusFetched"].ToObject<bool>(),
                DeviceId = json["user"]["device_id"].ToObject<string>(),
                OnlyDeviceId = json["user"]["onlyDeviceId"].ToObject<bool>(),
                KpOttSubscription = json["user"]["kpOttSubscription"].ToObject<string>(),
                HavePlus = json["user"]["havePlus"].ToObject<bool>(),
                HasAvatar = json["user"]["hasAvatar"].ToObject<bool>(),
                SignUpMethod = json["user"]["signUpMethod"].ToObject<string>(),
                IsHosted = json["user"]["isHosted"].ToObject<bool>(),
                IsYandex = json["user"]["isYandex"].ToObject<bool>(),
                ContactPhone = json["user"]["contactPhone"].ToObject<string>(),
                LastName = json["user"]["lastName"].ToObject<string>(),
                FirstName = json["user"]["firstName"].ToObject<string>(),
                Name = json["user"]["name"].ToObject<string>(),
                Login = json["user"]["login"].ToObject<string>(),
                Uid = json["user"]["uid"].ToObject<string>(),
                Settings = authUserSettings,
                HasEmail = json["user"]["hasEmail"].ToObject<bool>(),

            };

            return new YAuthInfoUserResponse
            {
                User = authUser,
                Experiments = json["experiments"].ToObject<string>()
            };
        }

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