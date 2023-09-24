using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MyDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDBUser"));
});

builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<IGroup, GroupServices>();



builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 1073741824;
});
builder.Services.AddAutoMapper(typeof(Program));




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

app.UseAuthorization();

app.MapControllers();

app.Run();
