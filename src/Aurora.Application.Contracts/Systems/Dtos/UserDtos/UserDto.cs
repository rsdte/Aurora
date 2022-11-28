using Aurora.Core.Mappers;
using Aurora.Domain.Systems.Users;

namespace Aurora.Application.Contracts.Systems.Dtos.UserDtos;

[Mapper(typeof(User))]
public class UserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string TenantId { get; set; }
    public string Password { get; set; }
}