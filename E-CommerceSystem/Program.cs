using AutoMapper;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using E_CommerceSystem.DAL.Registration;
using E_CommerceSystem.BLL.ServiceRegistration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ECommerceSystemContex>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ECommerceSystemContex>();

builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.DAServiceRegister(builder.Configuration);
builder.Services.Registers(); 


builder.Services.AddControllers();
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
