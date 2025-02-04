using AutoMapper;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using E_CommerceSystem.DAL.Registration;
using E_CommerceSystem.BLL.ServiceRegistration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using E_CommerceSystem.Entities.Helper;
using E_CommerceSystem.BLL.AutoMapper;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ECommerceSystemContex>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<ECommerceSystemContex>()
               .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(MapperPro));

builder.Services.DAServiceRegister(builder.Configuration);
builder.Services.Registers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation  
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "E-Commerce System  API",
        Description = "ASP.NET Core 8 Web API"
    });
    // To Enable authorization using Swagger (JWT)  
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});

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


