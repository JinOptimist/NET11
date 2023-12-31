using ChatApi.DatabaseStuff;
using ChatApi.DatabaseStuff.Models;
using ChatApi.FakeDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ChatApi;Trusted_Connection=True;";
builder.Services.AddDbContext<ChatApiContext>(op => op
                .UseLazyLoadingProxies()
                .UseSqlServer(ConnectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

//using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
//{
//    var context = serviceScope.ServiceProvider.GetRequiredService<ChatApiContext>();
//    context.Database.Migrate();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowAnyOrigin();
});

app.MapGet("/", () =>
{
    return $"go to /swagger/index.html";
});

app.MapGet("/c", () =>
{
    return FakeMessages.Messages.Count;
});

app.MapGet("/getMessages", (ChatApiContext webContext) =>
{
    //var messages = webContext.Messages.Take(10).ToList();
    var messages = FakeMessages.Messages.Take(10).ToList();
    var json = JsonSerializer.Serialize(messages);
    return json;
});

app.MapPost("/addMessage", ([FromBody]Message message, ChatApiContext webContext) =>
{
    if (message.CreateDateTime > DateTime.Now)
    {
        throw new ArgumentException("Invalid data. You are in future");
    }

    //webContext.Messages.Add(message);
    //webContext.SaveChanges();
    FakeMessages.Messages.Add(message);
    return true;
});

app.Run();
