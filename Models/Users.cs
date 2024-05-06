namespace JwtBearerImplementation.Models;

public record Users(
    int Id,
    string Name,
    string[] Roles
    );