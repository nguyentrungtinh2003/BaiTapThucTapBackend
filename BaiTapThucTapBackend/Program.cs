using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using BaiTapThucTapBackend.Services.Interface;
using BaiTapThucTapBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ket noi sql server
builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký HttpClient
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7153/") });

// Add service + repository
builder.Services.AddScoped<IDonViTinhRepository, DonViTinhRepository>();
builder.Services.AddScoped<IDonViTinhService, DonViTinhService>();

builder.Services.AddScoped<ILoaiSanPhamRepository, LoaiSanPhamRepository>();
builder.Services.AddScoped<ILoaiSanPhamService, LoaiSanPhamService>();

builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddScoped<ISanPhamService, SanPhamService>();

builder.Services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
builder.Services.AddScoped<INhaCungCapService, NhaCungCapService>();

builder.Services.AddScoped<IKhoRepository, KhoRepository>();
builder.Services.AddScoped<IKhoService, KhoService>();

builder.Services.AddScoped<IKhoUserRepository, KhoUserRepository>();
builder.Services.AddScoped<IKhoUserService, KhoUserService>();

builder.Services.AddScoped<INhapKhoRepository, NhapKhoRepository>();
builder.Services.AddScoped<INhapKhoService, NhapKhoService>();

// authen---
//builder.Services.AddAuthentication("Bearer")
//    .Add("Bearer", options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes("your_secret_key_123"))
//        };
//    });

//builder.Services.AddAuthorization();

var app = builder.Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

app.UseCors("AllowAll");

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
