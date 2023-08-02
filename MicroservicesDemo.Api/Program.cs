using Asp.Versioning;
using MicroservicesDemo.Api.Versioning.v1;
using MicroservicesDemo.Application;
using MicroservicesDemo.Application.Features.Users.Common;
using MicroservicesDemo.Infrastructure;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddApiExplorer(options => options.GroupNameFormat = "'v'VVV");
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();
var usersVersionSet = app.NewApiVersionSet("Users")
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();

app.UseHttpsRedirection();

#region API v1
var mapGroup = app.MapGroup("api/v1/users");

mapGroup.MapGet("/", TypedResultsMethods.GetAllUsersAsync)
    .Produces<IReadOnlyList<UserDto>>((int)HttpStatusCode.OK)
    .Produces((int)HttpStatusCode.NoContent)
    .WithApiVersionSet(usersVersionSet)
    .WithOpenApi();

mapGroup.MapPost("/", TypedResultsMethods.CreateUserAsync)
    .Produces<UserDto>((int)HttpStatusCode.Created)
    .WithApiVersionSet(usersVersionSet)
    .WithOpenApi();

mapGroup.MapPut("/", TypedResultsMethods.UpdateUserAsync)
    .Produces((int)HttpStatusCode.NoContent)
    .Produces((int)HttpStatusCode.NotFound)
    .Produces((int)HttpStatusCode.Conflict)
    .WithApiVersionSet(usersVersionSet)
    .WithOpenApi();

mapGroup.MapDelete("/{id}", TypedResultsMethods.DeleteUserAsync)
    .Produces((int)HttpStatusCode.NoContent)
    .Produces((int)HttpStatusCode.BadRequest)
    .WithApiVersionSet(usersVersionSet)
    .WithName("DeleteUser")
    .WithOpenApi();

mapGroup.MapGet("/{id}", TypedResultsMethods.GetUserById)
    .Produces<UserDto>((int)HttpStatusCode.OK)
    .Produces((int)HttpStatusCode.NotFound)
    .Produces((int)HttpStatusCode.BadRequest)
    .WithApiVersionSet(usersVersionSet)
    .WithOpenApi();
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();

            options.SwaggerEndpoint(url, name);
        }
    });
}

app.Run();