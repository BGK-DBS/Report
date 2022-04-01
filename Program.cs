using Microsoft.EntityFrameworkCore;
using ReportWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



// started with in memory db - commented out as moved to SQL db to persist data
//builder.Services.AddDbContext<ReportContext>(opt =>
//    opt.UseInMemoryDatabase("Reports"));

builder.Services.AddDbContext<ReportContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReportContext")));
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
