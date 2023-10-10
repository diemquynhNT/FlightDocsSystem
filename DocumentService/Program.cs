using DocumentService.Data;
using DocumentService.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MyDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DBDocument"));
});

builder.Services.AddScoped<IDocument, DocumentServices>();
builder.Services.AddScoped<IFlight, FlightService>();
builder.Services.AddScoped<ITypeDocument, TypeDocumentService>();
builder.Services.AddScoped<IGroup, GroupServices>();

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 1073741824; 
});
builder.Services.AddAutoMapper(typeof(Program));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("NoPermissionPolicy", policy =>
//        policy.RequireClaim("Permission", "NoPermission")); 

//    options.AddPolicy("ReadPolicy", policy =>
//        policy.RequireClaim("Permission", "Read"));

//    options.AddPolicy("ReadModifyPolicy", policy =>
//     policy.RequireClaim("Permission", "ReadModify"));
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
