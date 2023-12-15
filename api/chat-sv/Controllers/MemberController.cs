using chat_sv.DTOs.member;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Interfaces;

namespace TodoApi.Controllers
{
    [ApiController]  // ประกาศว่า Controller นี้เป็น ApiController
    [Route("api/v1/member")]  // กำหนด Route ของ Controller เป็น "api/v1/member"
    public class MemberController : ControllerBase  // ประกาศคลาส MemberController ที่สืบทอดมาจาก ControllerBase
    {
        private readonly ILogger<MemberController> _logger;  // ประกาศ Logger สำหรับ MemberController
        private readonly IMemberService _merService;  // ประกาศ Interface สำหรับ MemberService ที่จะถูกใช้ใน MemberController

        // Constructor ของ MemberController ที่รับ ILogger และ IMemberService เพื่อทำ Dependency Injection
        public MemberController(ILogger<MemberController> logger, IMemberService memberService)
        {
            _logger = logger;
            _merService = memberService;
        }

        [HttpGet]  // กำหนด HTTP Method เป็น GET
        [Route("members")]
        public ActionResult GetMembers([FromQuery] MemberParam param)  // ประกาศ Method ชื่อ GetMember ที่รับ MemberParam ผ่าน Query String
        {
            var members = _merService.GetMembers(param);  // เรียกใช้ GetMembers จาก IMemberService เพื่อดึงข้อมูลผู้ใช้
            return Ok(members);  // ส่งข้อมูลกลับในรูปแบบ HTTP 200 OK
        }

        [HttpGet]  // กำหนด HTTP Method เป็น GET
        [Route("detail/{id}")]
        public ActionResult GetMember([FromRoute] MemberParam param)  // ประกาศ Method ชื่อ GetMember ที่รับ MemberParam ผ่าน Query String
        {
            var member = _merService.GetMember(param);  // เรียกใช้ GetMembers จาก IMemberService เพื่อดึงข้อมูลผู้ใช้
            return Ok(member);  // ส่งข้อมูลกลับในรูปแบบ HTTP 200 OK
        }

        [HttpPost]
        [Route("members")]
        public IActionResult CreateTestData([FromBody] MemberBody newData)
        {
            if (newData == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                // Do something with newData
                return CreatedAtAction(nameof(CreateTestData), newData);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
