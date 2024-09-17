using LinkedinScrapper.Repositories;
using LinkedinScrapper.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IScrappedDataRepository, ScrappedDataRepository>();

// Services
builder.Services.AddScoped<Scraper>();
builder.Services.AddScoped<AssignmentService>();

// Database
builder.Services.AddDbContext<AssignmentDbContext>(opt =>
    opt.UseInMemoryDatabase("AssignmentDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

