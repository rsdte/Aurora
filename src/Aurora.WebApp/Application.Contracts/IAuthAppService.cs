namespace Aurora.WebApp.Application.Contracts;

public interface IAuthAppService
{
    Task<bool> Login(string username, string password);
}