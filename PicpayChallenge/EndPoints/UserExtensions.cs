using Microsoft.AspNetCore.Mvc;
using PicpayChallenge.Data.Entities;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.EndPoints;

public static class UserExtensions
{
    public static void AddUserEndPoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/users").WithTags("User");

        endpoints.MapGet("/{id:long}", async (
            [FromServices] IUserService service,
            long id) =>
        {
            var user = await service.GetUserIdAsync(id);

            return user is not null ?
                Results.Ok(user) :
                Results.NotFound();
        });

        endpoints.MapPost("", async (
            [FromServices] IUserService service,
            User user) =>
        {
            await service.CreateUserAsync(user);

            Results.NoContent();
        });

        endpoints.MapDelete("/{id:long}", async (
            [FromServices] IUserService service,
            long id) =>
        {
            await service.DeleteByIdAsync(id);

            Results.NoContent();
        });
    }
}
