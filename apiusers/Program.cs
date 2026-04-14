using apiusers.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Hardcoded list of user
var users = new List<apiusers.Models.User>
{
    new apiusers.Models.User { Id = 1, Name = "Pedro Antonio" },
    new apiusers.Models.User{ Id = 2, Name = "Jurandir Fernando" },
    new apiusers.Models.User { Id = 3, Name = "Marcelo Lima" },
    new apiusers.Models.User { Id = 4, Name = "Fernando Silva" },
};

// GET /users - Returns the list of all users
app.MapGet("/users", () =>
{
    return Results.Ok(users);
});

// POST /users - Returns true if the users name does NOT exist in the list
app.MapPost("/users", (apiusers.Models.User newUser) =>
{
    bool nameIsAvailable = !users.Any(g =>
        g.Name.Equals(newUser.Name, StringComparison.OrdinalIgnoreCase));

    return Results.Ok(new { available = nameIsAvailable });
});

app.Run();
