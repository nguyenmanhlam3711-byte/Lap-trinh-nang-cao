using MediatR;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Application.Interfaces;
using QuanLySinhVien.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllers();

// 2. CẤU HÌNH DATABASE
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. DI cho ApplicationDbContext (Đăng ký Interface để tầng Application có thể dùng)
builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());

// 4. CẤU HÌNH MEDIATR (Đã sửa lại đúng cú pháp cho bản mới)
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(QuanLySinhVien.Application.Features.Sinhvien.Commands.Create.CreateSinhVienHandler).Assembly);
});

// 5. Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();