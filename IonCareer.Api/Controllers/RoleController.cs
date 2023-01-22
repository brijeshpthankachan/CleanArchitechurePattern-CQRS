using System.Net;
using IonCareer.Api.Controllers.Common;
using IonCareer.Application.Dtos;
using IonCareer.Application.Features.RoleManagement.Queries;
using Microsoft.AspNetCore.Mvc;

namespace IonCareer.Api.Controllers;

[Route("api")]
[ApiController]
public class RoleController : BaseController
{
    [HttpGet("roles")]
    [ProducesResponseType(typeof(List<RoleDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetRoles()
    {
        var result = await Mediator.Send(new GetRoleDataQuery());
        return Ok(result);
    }
}