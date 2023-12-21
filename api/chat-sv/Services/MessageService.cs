using Microsoft.AspNetCore.Mvc;
using chat_sv.DTOs.message;
using TodoApi.Interfaces;

namespace TodoApi.Services
{

    public class MessageService : ControllerBase, IMessageService
    {
        private readonly List<MessageModels> _messages;

        public MessageService()
        {

            _messages = new List<MessageModels>
        {
            new MessageModels { MessageId = 1, Content = "Hello", MemberId = 1 },
            new MessageModels { MessageId = 2, Content = "Hi there", MemberId = 2 },
            new MessageModels { MessageId = 3, Content = "Greetings", MemberId = 1 }
        };
        }

        public IEnumerable<MessageModels> GetMessagesByMemberId(int memberId)
        {
            return _messages.Where(m => m.MemberId == memberId);
        }

        public ActionResult AddMessage([FromBody] MessageBody body)
        {
            var messages = _messages;
            if (body == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var newmessage = new MessageModels { MessageId = messages.Count + 1, Content = body.Content, MemberId = body.MemberId };

                messages.Add(newmessage);

                return StatusCode(201, messages);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
