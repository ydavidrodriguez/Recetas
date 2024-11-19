using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recetas.Application.ExceptionManager;
using Recetas.Application.RequestManager.Commands;

namespace Recetas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class RecetasController : ControllerBase
    {
        #region
        private readonly IMediator _mediator;
        #endregion

        public RecetasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostCreateRecetas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionManager))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ExceptionManager))]
        public async Task<IActionResult> PostCreateCitas()
        {
            return await _mediator.Send(new PostReceiveCreateRecetasCommand
            {
                
            });

        }
        //[HttpGet("getCitaById")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionManager))]
        //[ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ExceptionManager))]
        //public async Task<IActionResult> getCitaById([FromQuery] Guid idCita)
        //{
        //    return await _mediator.Send(new GetListCitasByIdCommand
        //    {
        //        IdCita = idCita
        //    });
        //}
    }
}
