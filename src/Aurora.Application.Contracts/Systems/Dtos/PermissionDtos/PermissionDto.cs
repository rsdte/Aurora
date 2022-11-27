using Aurora.Domain.Shared.Systems.Permissions;

namespace Aurora.Application.Contracts.Systems.Dtos.PermissionDtos;

public class PermissionDto
{
    public string Name { get; set; }
    public string Url { get; set; }
    public PermissionType Type { get; set; }
    // public PermissionTypeText TypeText { get; set; }
    public string Icon { get; set; }
    public ICollection<PermissionDto> Children { get; set; } = new List<PermissionDto>();
    public string Id { get; set; }
    public string? ParentId { get; set; }
}