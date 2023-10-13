using API.Models;
namespace API.Services;

public interface IUserService
{   
    // * Metodo para registrar usuario
    Task<UserResponse> Registrar(UserRequest request);
    // * Metodo para loguaer usuario
    Task<UserResponse> Loguear(UserRequest request); 
}