using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddOcelot();

var app = builder.Build();

app.MapGet("/", () => "Microservices Demo - API Gateway with Ocelot");

await app.UseOcelot();

app.Run();
