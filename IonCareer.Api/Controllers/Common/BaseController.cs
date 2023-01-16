using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IonCareer.Api.Controllers.Common
{
    [Route("api")]
    [ApiController]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
