using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using UserService.Data;
using UserService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MyDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDBUser"));
});

builder.Services.AddScoped<IUser, UserServices>();



builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 1073741824;
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpClient<UserServices>();

//JWT
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var sk = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication
    (JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(sk),
            ClockSkew = TimeSpan.Zero
        };
    }
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
