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
            new MemberModels { Id = 1, Name = "test_1" },
            new MemberModels { Id = 2, Name = "test_2" }
        };

        // คุณสมบัติสำหรับการเข้าถึงและกำหนดค่ารายการสมาชิก
        public static List<MemberModels> Members { get => members; set => members = value; }
    }
}