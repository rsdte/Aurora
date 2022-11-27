namespace Aurora.Application.Contracts.Systems.Dtos.RoleDtos;

public class AddPermissionDto
{
    public string RoleId { get; set; }
    public List<string> PermissionIds { get; set; } = new List<string>();
}