var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "I'm room api. Look at /m");

app.MapGet("/m", async () =>
{
    var httpClient = new HttpClient();
    var response = await httpClient.GetAsync("http://chat/c");
    var data = await response.Content.ReadAsStringAsync();
    var count = int.Parse(data);
    return $"Total message count in all room in all chats {count}";
});

app.Run();
