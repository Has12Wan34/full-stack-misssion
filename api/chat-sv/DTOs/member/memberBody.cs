using Newtonsoft.Json;

namespace chat_sv.DTOs.member
{
    public class MemberBody
    {
        [JsonProperty("id")]
        public int Id { get; set; } //? ไม่จำเป็น

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
