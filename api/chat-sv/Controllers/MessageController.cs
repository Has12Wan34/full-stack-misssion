using chat_sv.DTOs.member;
using chat_sv.DTOs.message;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Interfaces;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/v1/message")]
    public class MembersController : ControllerBase
    {
        private readonly IMessageService _message;

        public MembersController(IMessageService repository)
        {
            _message = repository;
        }

        [HttpGet("messages/{id}")]
        public IEnumerable<MessageModels> GetMessagesByMemberId(int id)
        {
            return _message.GetMessagesByMemberId(id);
        }
    }

}
