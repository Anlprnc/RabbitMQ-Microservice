using Microsoft.EntityFrameworkCore;
using PostService.Models;
using PostService.ServiceBus;
using PostService.Services.PostService;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(conString));

builder.Services.AddScoped<IPostService, PostServices>();
builder.Services.AddSingleton<IPostServiceBus, PostServiceBus>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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