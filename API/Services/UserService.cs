using API.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class UserService : IUserService
{
    private readonly DbAppContext _context;
    private readonly IConfiguration _configuration;

    public UserService(DbAppContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<UserResponse> Registrar(UserRequest request)
    {
        var usuarioExistente = _context.Users.FirstOrDefault(
            x => x.Username == request.Username);
        if (usuarioExistente != null)
        {
            return new UserResponse { Result = false, Msg = "El usuario ingresado ya existe!" };
        }

        var newUser = new User
        {
            Email = request.Email,
            Username = request.Username,
            Password = request.Password
        };

        _context.Users.Add(newUser);

        await _context.SaveChangesAsync();

        return new UserResponse { Result = true, Msg = "Tu registro fue exitoso!" };
    }

    public async Task<UserResponse> Loguear(UserRequest request)
    {
        var usuarioEncontrado = await _context.Users
            .FirstOrDefaultAsync(x =>
                x.Username == request.Username &&
                x.Password == request.Password
            );
        if (usuarioEncontrado != null)
        {
            return new UserResponse { Result = true, Msg = "Tu inicio de sesión fue exitoso!" };
        }
        else
        {
            return new UserResponse { Result = false, Msg = "Credenciales de inicio de sesión incorrectas!" };
        }
    }
}