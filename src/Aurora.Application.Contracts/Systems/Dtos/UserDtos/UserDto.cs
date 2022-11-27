namespace Aurora.Application.Contracts.Systems.Dtos.UserDtos;

public class UserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string TenantId { get; set; }
    public string Password { get; set; }
}