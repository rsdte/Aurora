using Aurora.Application.Contracts;
using Aurora.Application.Contracts.Systems;
using Aurora.Application.Contracts.Systems.Dtos.UserDtos;
using Aurora.Core.Common;
using Aurora.Core.Extensions;
using Aurora.Domain.Shared.Utils;
using Aurora.Domain.Systems.UserRoles;
using Aurora.Domain.Systems.Users;

namespace Aurora.Application.Systems;

public class UserAppService: IUserAppService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IRoleAppService _roleAppService;
    private readonly IOperator _operator;

    public UserAppService(
        IUserRepository userRepository, 
        IUserRoleRepository userRoleRepository, 
        IRoleAppService roleAppService, 
        IOperator @operator
        )
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _roleAppService = roleAppService;
        _operator = @operator;
    }

    /// <inheritdoc />
    public async Task<UserDto> GetDataAsync(string userName)
    {
        var user = await _userRepository.FindAsync(p => p.UserName == userName);
        if (user.IsNullOrEmpty())
            return default;
        return new UserDto
        {
            UserName = user.UserName,
            Id = user.Id,
            Password = user.Password,
            TenantId = user.TenantId
        };
    }

    /// <inheritdoc />
    public async Task AddRoleAsync(AddRoleToUser input)
    {
        var user = await _userRepository.FindAsync(p => p.Id == input.UserId);
        if (user.IsNullOrEmpty())
            throw new BusException("未找到用户");

        var userRole = await _userRoleRepository.FindAsync(p => p.UserId == input.UserId && p.RoleId == input.RoleId);
        if (!userRole.IsNullOrEmpty())
            return;
        var role = await _roleAppService.GetData(input.RoleId);
        if (role.IsNullOrEmpty())
            throw new BusException("未找到指定角色");

        await _userRoleRepository.InsertAsync(new UserRole
        {
            CreateTime = DateTime.Now,
            CreatorId = _operator.UserId,
            UserId = input.UserId,
            Deleted = false,
            Id = IdHelper.Get(),
            RoleId = role.Id,
            TenantId = role.TenantId,
        });
    }

}