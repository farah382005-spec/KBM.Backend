using KBM.Application.Interfaces;
using KBM.Infrastructure.Repositories;
using KBM.Application.Mappings;
using KBM.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

using KBM.Application.Services;
using KBM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
MappingConfig.RegisterMappings();

builder.Services.AddControllers();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<LessonService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
