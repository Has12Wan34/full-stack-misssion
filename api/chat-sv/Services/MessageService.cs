using Microsoft.AspNetCore.Mvc;
using chat_sv.DTOs.message;
using TodoApi.Interfaces;
using chat_sv.DTOs.member;

namespace TodoApi.Services
{

    public class MessageService : ControllerBase, IMessageService
    {

        public IEnumerable<MessageModels> GetMessagesByMemberId(int memberId)
        {
            var messages = MessageStore.Messages;
            return messages.Where(m => m.MemberId == memberId);
        }

        public ActionResult AddMessage([FromBody] MessageBody body)
        {
            if (body == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var messages = MessageStore.Messages;
                // Create a new message
                var newMessage = new MessageModels
                {
                    MessageId = messages.Count + 1,
                    Content = body.Content,
                    MemberId = body.MemberId
                };

                // Add the new message to the list
                messages.Add(newMessage);

                // Return the updated list of messages
                return StatusCode(201, messages.Where(x => x.MemberId == body.MemberId));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
