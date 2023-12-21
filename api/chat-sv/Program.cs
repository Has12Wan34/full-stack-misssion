// นำเข้าหลายๆ namespace ที่จำเป็น
using Newtonsoft.Json.Serialization;
using TodoApi.Interfaces;
using TodoApi.Services;

// สร้าง Builder สำหรับการสร้าง Web Application ด้วย ASP.NET Core
var builder = WebApplication.CreateBuilder(args);

// เพิ่มบริการ Controllers เข้าไปใน container
builder.Services.AddControllers();

// เพิ่มบริการ Api Explorer สำหรับ Endpoints
builder.Services.AddEndpointsApiExplorer();

// เพิ่ม SwaggerGen เพื่อสร้าง Swagger/OpenAPI documentation
builder.Services.AddSwaggerGen();

// เพิ่มบริการ MemberService เข้าไปใน container โดยระบุว่าต้องมีอย่างละตัว (Scoped)
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMessageService, MessageService>();

object value = builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });

// สร้าง instance ของ Web Application
var app = builder.Build();

// กำหนดการกำหนดค่า pipeline ของ HTTP request
if (app.Environment.IsDevelopment())
{
    // ในโหมด Development, เราใช้ Swagger และ Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ให้ทำการ Redirect HTTP เป็น HTTPS
app.UseHttpsRedirection();

// ทำการให้เว็บแอปพลิเคชันใช้งาน Authorization
app.UseAuthorization();

// Map Controllers เพื่อระบุเส้นทางของ Controller
app.MapControllers();

// เริ่มต้นการทำงานของเว็บแอปพลิเคชัน
app.Run();
