using CommentService.CommentBackgroundServices.PostBackgroundProcessor;
using CommentService.EventProcessing.PostProcessors;
using CommentService.Models;
using CommentService.Services.CommentService;
using CommentService.Services.PostService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(conString));

builder.Services.AddScoped<ICommentService, CommentServices>();
builder.Services.AddScoped<IPostService, PostServices>();
builder.Services.AddSingleton<IAddPostEventProcessor, AddPostEventProcessor>();
builder.Services.AddHostedService<PostMessageSubscriber>();

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