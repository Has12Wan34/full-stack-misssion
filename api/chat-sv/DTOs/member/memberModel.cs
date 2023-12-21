using Newtonsoft.Json;

namespace chat_sv.DTOs.member
{
    public class MemberModels
    {
        [JsonProperty("member_id")]
        public int MemberId {get; set;}

        [JsonProperty("name")]
        public string? Name {get; set;}
    }
}