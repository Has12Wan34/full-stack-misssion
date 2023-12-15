using TodoApi.Interfaces;
using TodoApi.DTOs;
using chat_sv.DTOs.member;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TodoApi.Services
{
    // คลาส MemberService ที่ implements interface IMemberService
    public class MemberService : ControllerBase, IMemberService
    {
        // สร้างตัวแปร List หรือ Database ที่จะใช้เก็บข้อมูล
        private readonly List<MemberBody> _member = new List<MemberBody>();
        // ฟังก์ชัน GetMembers ที่รับพารามิเตอร์เป็น MemberParam และคืนค่า IEnumerable ของ MemberModels
        public IEnumerable<MemberModels> GetMembers(MemberParam param)
        {
            // ดึงข้อมูลผู้ใช้จาก MemberStore
            var members = MemberStore.Members;

            // ตรวจสอบว่ามีชื่อที่ไม่ว่างเปล่าหรือไม่
            if (!string.IsNullOrEmpty(param.Name))
            {
                // แปลงชื่อที่รับเข้ามาให้เป็นตัวพิมพ์เล็กทั้งหมด
                var name = param.Name!.ToLower();

                // กรองรายการผู้ใช้เฉพาะที่มีชื่อที่ตรงกับที่ระบุ (ไม่สนใจตัวพิมพ์)
                members = members.Where(x => x.Name!.ToLower()!.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            // คืนรายการผู้ใช้ที่ผ่านการกรอง
            return members;
        }

        public ActionResult GetMember(MemberParam route)
        {
            var members = MemberStore.Members;

            // ตรวจสอบว่ามีชื่อที่ไม่ว่างเปล่าหรือไม่
            if (route.Id != 0 || route.Id != null)
            {

                // กรองรายการผู้ใช้เฉพาะที่มีชื่อที่ตรงกับที่ระบุ (ไม่สนใจตัวพิมพ์)
                var member = members.FirstOrDefault(x => x.Id! == route.Id);
                // คืนรายการผู้ใช้ที่ผ่านการกรอง
                return Ok(member);
            }
            return NotFound($"Member with ID {route.Id} not found.");
        }

        public ActionResult AddMember([FromBody] MemberBody body)
        {
            var members = MemberStore.Members;
            if (body == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var newmember = new MemberModels { Id = members.Count + 1, Name = body.Name };

                members.Add(newmember);

                return StatusCode(201, members);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        public ActionResult DeleteMember([FromRoute] MemberParam param)
        {
            var members = MemberStore.Members;

            // ค้นหาสมาชิกที่ต้องการลบตาม ID
            var memberToDelete = members.FirstOrDefault(x => x.Id == param.Id);

            if (memberToDelete == null)
            {
                // ถ้าไม่พบสมาชิกที่ต้องการลบ
                return NotFound($"Member with ID {param.Id} not found.");
            }

            try
            {
                // ลบสมาชิกจากรายชื่อ
                members.Remove(memberToDelete);

                return StatusCode(200, new { status = 200, message = "deleted success" });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        public ActionResult UpdateMember([FromRoute, FromBody] MemberParam param, MemberBody member)
        {
            var members = MemberStore.Members;

            // ค้นหาสมาชิกที่ต้องการอัปเดตตาม ID
            var memberToUpdate = members.FirstOrDefault(x => x.Id == param.Id);

            if (memberToUpdate == null)
            {
                // ถ้าไม่พบสมาชิกที่ต้องการอัปเดต
                return NotFound($"Member with ID {param.Id} not found.");
            }

            try
            {
                // อัปเดตข้อมูลสมาชิก
                memberToUpdate.Name = member.Name;

                return Ok(memberToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
