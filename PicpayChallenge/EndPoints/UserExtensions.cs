using Microsoft.AspNetCore.Mvc;
using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Repositories.Interfaces;

namespace PicpayChallenge.EndPoints;

public static class UserExtensions
{
    public static void AddUserEndPoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/users").WithTags("User");

        endpoints.MapGet("/{id:long}", async (
            [FromServices] IUserRepository repository,
            long id) =>
        {
            var user = await repository.GetByIdAsync(id);

            return user is not null ?
                Results.Ok(user) :
                Results.NotFound();
        });

        endpoints.MapPost("", async (
            [FromServices] IUserRepository repository,
            User user) =>
        {
            await repository.CreateUserAsync(user);

            Results.NoContent();
        });
    }
}
