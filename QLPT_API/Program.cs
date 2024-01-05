using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QLPT_API.Entities;
using System.Text;
using Microsoft.OpenApi.Models;
using QLPT_API.Services.IService;
using QLPT_API.Services.Service;
using QLPT_API.Handles.Converters;
using QLPT_API.Handles.Response;
using QLPT_API.Handles.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Value.ToString();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(allowedOrigin);
                      });
});

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("QLPTConnectionString")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IChuaService, ChuaService>();
builder.Services.AddScoped<IDaoTrangService, DaoTrangService>();
builder.Services.AddScoped<IDonDangKyService, DonDangKyService>();
builder.Services.AddScoped<IPhatTuService, PhatTuService>();
builder.Services.AddScoped<IBaiVietService, BaiVietService>();
builder.Services.AddScoped<IBinhLuanService, BinhLuanService>();

builder.Services.AddSingleton<PhatTuConverter>();
builder.Services.AddSingleton<ChuaConverter>();
builder.Services.AddSingleton<DonDangKyConverter>();
builder.Services.AddSingleton<DaoTrangConverter>();
builder.Services.AddSingleton<PhatTuDaoTrangConverter>();
builder.Services.AddSingleton<TrangThaiDonConverter>();
builder.Services.AddSingleton<BaiVietConverter>();
builder.Services.AddSingleton<TrangThaiBaiVietConverter>();
builder.Services.AddSingleton<BinhLuanBaiVietConverter>();
builder.Services.AddSingleton<NguoiDungThichBaiVietConverter>();
builder.Services.AddSingleton<NguoiDungThichBinhLuanBaiVietConverter>();
builder.Services.AddSingleton<ResponseObject<PhatTuDTO>>();
builder.Services.AddSingleton<ResponseObject<TokenDTO>>();
builder.Services.AddSingleton<ResponseObject <ChuaDTO>>();
builder.Services.AddSingleton<ResponseObject<DonDangKyDTO>>();
builder.Services.AddSingleton<ResponseObject<DaoTrangDTO>>();
builder.Services.AddSingleton<ResponseObject<BaiVietDTO>>();
builder.Services.AddSingleton<ResponseObject<BinhLuanBaiVietDTO>>();



var secretKey = builder.Configuration["Jwt:Key"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

// Authenticate
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // tự cấp token
        ValidateIssuer = false,
        ValidateAudience = false,
        // ký vào token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
    // https://Localhost:1234/Images
});


app.MapControllers();

app.Run();
