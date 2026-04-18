using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YValidateSquatter
    {
        [JsonProperty("require_flow_with_fio")]
        public bool RequireFlowWithFio { get; set; }

        [JsonProperty("require_flow_with_auth_hint")]
        public bool RequireFlowWithAuthHint { get; set; }

        [JsonProperty("auth_hint_question_id")]
        public string AuthHintQuestionId { get; set; }

        [JsonProperty("suggestBy")]
        public string SuggestBy { get; set; }
    }
}