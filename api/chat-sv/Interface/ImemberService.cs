using chat_sv.DTOs.member;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;

// นิยาม interface ที่ใช้ในการจัดการข้อมูลสมาชิก
namespace TodoApi.Interfaces
{
    public interface IMemberService
    {
        // ส่งคืนรายชื่อสมาชิกตามเงื่อนไขที่กำหนด
        public ActionResult GetMember(MemberParam param);
        public IEnumerable<MemberModels> GetMembers(MemberParam param);
        public ActionResult AddMember(MemberBody member);
        public ActionResult DeleteMember(MemberParam param);
        public ActionResult UpdateMember(MemberParam param, MemberBody member);
    }
}



