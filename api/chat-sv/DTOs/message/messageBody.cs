using Newtonsoft.Json;

namespace chat_sv.DTOs.message
{
    public class MessageBody
    {
        [JsonProperty("message_id")]
        public int MessageId { get; set; }
        [JsonProperty("content")]
        public string? Content { get; set; }
        [JsonProperty("member_id")]
        public int MemberId { get; set; }
    }
}
