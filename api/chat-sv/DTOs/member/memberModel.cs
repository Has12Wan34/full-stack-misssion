using Newtonsoft.Json;

namespace chat_sv.DTOs.member
{
    public class MemberModels
    {
        [JsonProperty("id")]
        public int Id {get; set;}

        [JsonProperty("name")]
        public string? Name {get; set;}
    }
}