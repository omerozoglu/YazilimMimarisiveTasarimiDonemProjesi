using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Dieticians.Commands.Create;
using Application.Features.Dieticians.Commands.Delete;
using Application.Features.Dieticians.Commands.Update;
using Application.Features.Dieticians.Queries.Get;
using Application.Features.Dieticians.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]

    [Route ("api/v1/[controller]")]
    public class DieticianController : Controller {
        private readonly IMediator _mediator;

        public DieticianController (IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [Route ("Dietician")]
        [ProducesResponseType (typeof (BaseResponse<Dietician>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Dietician>>> GetDieticians () {
            var query = new GetListDieticianQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpGet]
        [Route ("Dietician/{id:length(24)}")]
        [ProducesResponseType (typeof (BaseResponse<Dietician>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Dietician>>> GetDietician (string id) {
            var query = new GetDieticianQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpPost]
        [Route ("Dietician")]
        [ProducesResponseType (typeof (BaseResponse<Dietician>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Dietician>>> CreateDietician (CreateDieticianCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Dietician> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpPut]
        [Route ("Dietician")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Dietician>>> UpdateDietician (UpdateDieticianCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Dietician> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpDelete]
        [Route ("Dietician")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Dietician>>> DeleteDietician (DeleteDieticianCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
    }
}