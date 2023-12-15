using TodoApi.Interfaces;
using TodoApi.DTOs;
using chat_sv.DTOs.member;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Services
{
    // คลาส MemberService ที่ implements interface IMemberService
    public class MemberService : ControllerBase, IMemberService
    {
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


        public ActionResult GetMember(MemberParam param)
        {
            var members = MemberStore.Members;

            // ตรวจสอบว่ามีชื่อที่ไม่ว่างเปล่าหรือไม่
            if (param.Id != 0 || param.Id != null)
            {

                // กรองรายการผู้ใช้เฉพาะที่มีชื่อที่ตรงกับที่ระบุ (ไม่สนใจตัวพิมพ์)
                var member = members.FirstOrDefault(x => x.Id! == param.Id);
                // คืนรายการผู้ใช้ที่ผ่านการกรอง
                return Ok(member);
            }
            return Ok("Err");
        }
    }
}
