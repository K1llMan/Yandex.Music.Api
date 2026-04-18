using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YCheckAvailabilityResult
    {
        [JsonProperty("antifraudScore")]
        public string AntifraudScore { get; set; }

        [JsonProperty("hasAvailableAccounts")]
        public bool HasAvailableAccounts { get; set; }

        [JsonProperty("flnFlowRequired")]
        public bool FlnFlowRequired { get; set; }

        [JsonProperty("can_use_push")]
        public bool CanUsePush { get; set; }

        [JsonProperty("can_use_webauthn")]
        public bool CanUseWebauthn { get; set; }

        [JsonProperty("has_master")]
        public bool HasMaster { get; set; }

        [JsonProperty("is_session_mastered")] 
        public bool IsSessionMastered { get; set; }

        [JsonProperty("does_master_have_free_slots")]
        public bool DoesMasterHaveFreeSlots { get; set; }

        [JsonProperty("allowed_registration_flows")]
        public List<object> AllowedRegistrationFlows { get; set; }

        [JsonProperty("SuggestBy")]
        public string SuggestBy { get; set; }

        [JsonProperty("master_info")]
        public YMasterInfo MasterInfo { get; set; }
    }
}