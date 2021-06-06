using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.DietMethods.Commands.Create;
using Application.Features.DietMethods.Commands.Delete;
using Application.Features.DietMethods.Commands.Update;
using Application.Features.DietMethods.Queries.Get;
using Application.Features.DietMethods.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/v1/[controller]")]
    public class DietMethodController : Controller {
        private readonly IMediator _mediator;

        public DietMethodController (IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType (typeof (BaseResponse<DietMethod>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<DietMethod>>> GetDietMethods () {
            var query = new GetListDietMethodQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpGet]
        [Route ("{id:length(24)}")]
        [ProducesResponseType (typeof (BaseResponse<DietMethod>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<DietMethod>>> GetDietMethod (string id) {
            var query = new GetDietMethodQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpPost]
        [ProducesResponseType (typeof (BaseResponse<DietMethod>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<DietMethod>>> CreateDietMethod (CreateDietMethodCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<DietMethod> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpPut]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<DietMethod>>> UpdateDietMethod (UpdateDietMethodCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<DietMethod> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpDelete]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<DietMethod>>> DeleteDietMethod (DeleteDietMethodCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
    }
}