using CosmeticApp5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CosmeticApp5.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=ERJETA13\\SQLEXPRESS01;Initial Catalog=store-db;Integrated Security=True;Trusted_Connection=True;Encrypt=False;Pooling=False"));

builder.Services.AddScoped<ProductService>();

builder.Services.AddDbContext<AppDbContext>
  (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));


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