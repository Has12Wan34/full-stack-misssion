using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chat_sv.DTOs.message;

namespace chat_sv.DTOs.member
{
    public static class MessageStore
    {
        // กำหนดรายการสมาชิกเริ่มต้น
        private static List<MessageModels> messages = new List<MessageModels>
        {
            new MessageModels { MessageId = 1, Content = "Hello", MemberId = 1 },
            new MessageModels { MessageId = 2, Content = "Hi there", MemberId = 2 },
            new MessageModels { MessageId = 3, Content = "Greetings", MemberId = 1 }
        };

        // คุณสมบัติสำหรับการเข้าถึงและกำหนดค่ารายการสมาชิก
        public static List<MessageModels> Messages { get => messages; set => messages = value; }
    }
}