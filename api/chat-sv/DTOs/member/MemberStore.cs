using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_sv.DTOs.member
{
    public static class MemberStore
    {
        // กำหนดรายการสมาชิกเริ่มต้น
        private static List<MemberModels> members = new List<MemberModels>
        {
            new MemberModels { MemberId = 1, Name = "Wan" },
            new MemberModels { MemberId = 2, Name = "Suha" }
        };

        // คุณสมบัติสำหรับการเข้าถึงและกำหนดค่ารายการสมาชิก
        public static List<MemberModels> Members { get => members; set => members = value; }
    }
}