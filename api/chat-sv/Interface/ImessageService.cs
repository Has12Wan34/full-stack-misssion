using chat_sv.DTOs.message;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<MessageModels> GetMessagesByMemberId(int memberId);
        public ActionResult AddMessage(MessageBody message);
    }
}