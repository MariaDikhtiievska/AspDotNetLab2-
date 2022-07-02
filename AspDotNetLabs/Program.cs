using AspDotNetLabs.Middlewares;
using AspDotNetLabs.Services;
using System.Text;
using System.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TimerService>();
builder.Services.AddScoped<RandomService>();
builder.Services.AddSingleton<GeneralCounterService>();

var app = builder.Build();

app.UseMiddleware<TimerMiddleware>();
app.UseMiddleware<RandomMiddleware>();
app.UseMiddleware<GeneralCounterMiddleware>();

//app.MapGet("/services/timer", async context =>
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var timerService = scope.ServiceProvider.GetRequiredService<TimerService>();
//        await context.Response.WriteAsync($"timerService: {timerService.GetDateTimeNow()}");
//    }
//});

//app.MapGet("/services/random", async context =>
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var randomService1 = scope.ServiceProvider.GetRequiredService<RandomService>();
//        var randomService2 = scope.ServiceProvider.GetRequiredService<RandomService>();
//        await context.Response.WriteAsync($"randomService1: {randomService1.Value}, randomService2: {randomService2.Value}");
//    }
//});

//app.MapGet("/services/general-counter", async context =>
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var generalCounterService = scope.ServiceProvider.GetRequiredService<GeneralCounterService>();
//        await context.Response.WriteAsync($"generalCounterService: {generalCounterService.Count}");
//    }
//});

app.MapGet("/services/list", async context =>
{
    var stringBuilder = new StringBuilder();
    stringBuilder.Append("<h1>All services</h1>");
    stringBuilder.Append("<table border=\"1\">");
    stringBuilder.Append("<tr><th>Type</th><th>Lifetime</th><th>Implementation</th></tr>");
    foreach (var service in builder.Services.ToList())
    {
        stringBuilder.Append("<tr>");
        stringBuilder.Append($"<td>{service.ServiceType.FullName}</td>");
        stringBuilder.Append($"<td>{service.Lifetime}</td>");
        stringBuilder.Append($"<td>{service.ImplementationType?.FullName}</td>");
        stringBuilder.Append("</tr>");
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());
});

app.Run();
