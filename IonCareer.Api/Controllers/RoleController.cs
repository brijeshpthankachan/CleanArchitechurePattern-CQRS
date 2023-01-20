using IonCareer.Api.Controllers.Common;
using IonCareer.Application.Dtos;
using IonCareer.Application.Features.RoleManagement.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IonCareer.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RoleController : BaseController
    {
        [HttpGet("roles")]
        [ProducesResponseType(typeof(List<RoleDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRoles()
        {
            var Result = await Mediator.Send(new GetRoleDataQuery());
            return Ok(Result);
        }
    }
}
