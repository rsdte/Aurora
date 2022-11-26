using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aurora.HostApi.Controllers;

/// <summary>
/// 基础控制器
/// </summary>
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("/api/[controller]/[action]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
}