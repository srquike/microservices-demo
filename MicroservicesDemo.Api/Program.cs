using Asp.Versioning.Conventions;
using MicroservicesDemo.Api.Versioning.v1;
using System.Net;
using MicroservicesDemo.Application;
using MicroservicesDemo.Infrastructure;
using MicroservicesDemo.Application.Features.Users.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options => options.ReportApiVersions = true)
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "v'VVV'";
    });
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

var users = app.NewApiVersionSet("Users").Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region API v1
var mapGroup = app.MapGroup("api/v1/user");

mapGroup.MapGet("/", TypedResultsMethods.GetAllUsersAsync)
    .Produces<IList<UserDto>>()
    .Produces((int)HttpStatusCode.NoContent)
    .WithApiVersionSet(users)
    .HasApiVersion(1);

mapGroup.MapPost("/", TypedResultsMethods.CreateUserAsync)
    .Produces<UserDto>()
    .Produces((int)HttpStatusCode.BadRequest)
    .Produces((int)HttpStatusCode.Created)
    .Produces((int)HttpStatusCode.Conflict)
    .WithApiVersionSet(users)
    .HasApiVersion(1);

mapGroup.MapPut("/{id}", TypedResultsMethods.UpdateUserAsync)
    .Produces((int)HttpStatusCode.NoContent)
    .Produces((int)HttpStatusCode.NotFound)
    .Produces((int)HttpStatusCode.Conflict)
    .WithApiVersionSet(users)
    .HasApiVersion(1);

mapGroup.MapDelete("/{id}", TypedResultsMethods.DeleteUserAsync)
    .Produces((int)HttpStatusCode.NoContent)
    .Produces((int)HttpStatusCode.BadRequest)
    .WithApiVersionSet(users)
    .HasApiVersion(1);
#endregion

app.Run();
