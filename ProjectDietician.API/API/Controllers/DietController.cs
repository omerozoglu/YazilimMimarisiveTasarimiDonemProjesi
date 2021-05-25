using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Diets.Commands.Create;
using Application.Features.Diets.Commands.Delete;
using Application.Features.Diets.Commands.Update;
using Application.Features.Diets.Queries.Get;
using Application.Features.Diets.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/v1/[controller]")]
    public class DietController : Controller {
        private readonly IMediator _mediator;

        public DietController (IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [Route ("Diet")]
        [ProducesResponseType (typeof (BaseResponse<Diet>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Diet>>> GetDiets () {
            var query = new GetListDietQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpGet]
        [Route ("Diet/{id:length(24)}")]
        [ProducesResponseType (typeof (BaseResponse<Diet>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Diet>>> GetDiet (string id) {
            var query = new GetDietQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpPost]
        [Route ("Diet")]
        [ProducesResponseType (typeof (BaseResponse<Diet>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Diet>>> CreateDiet (CreateDietCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Diet> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpPut]
        [Route ("Diet")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Diet>>> UpdateDiet (UpdateDietCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Diet> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpDelete]
        [Route ("Diet")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Diet>>> DeleteDiet (DeleteDietCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
    }
}