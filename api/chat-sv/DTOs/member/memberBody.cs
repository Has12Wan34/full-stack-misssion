using Newtonsoft.Json;

namespace chat_sv.DTOs.member
{
    public class MemberBody
    {
        [JsonProperty("member_id")]
        public int MemberId { get; set; } //? ไม่จำเป็น

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
