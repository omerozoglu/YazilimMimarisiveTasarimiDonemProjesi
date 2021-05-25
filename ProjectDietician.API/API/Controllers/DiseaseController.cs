using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Diseases.Commands.Create;
using Application.Features.Diseases.Commands.Delete;
using Application.Features.Diseases.Commands.Update;
using Application.Features.Diseases.Queries.Get;
using Application.Features.Diseases.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diseases;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/v1/[controller]")]
    public class DiseaseController : Controller {
        private readonly IMediator _mediator;

        public DiseaseController (IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [Route ("Disease")]
        [ProducesResponseType (typeof (BaseResponse<Disease>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Disease>>> GetDiseases () {
            var query = new GetListDiseaseQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpGet]
        [Route ("Disease/{id:length(24)}")]
        [ProducesResponseType (typeof (BaseResponse<Disease>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Disease>>> GetDisease (string id) {
            var query = new GetDiseaseQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpPost]
        [Route ("Disease")]
        [ProducesResponseType (typeof (BaseResponse<Disease>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Disease>>> CreateDisease (CreateDiseaseCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Disease> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpPut]
        [Route ("Disease")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Disease>>> UpdateDisease (UpdateDiseaseCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Disease> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpDelete]
        [Route ("Disease")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Disease>>> DeleteDisease (DeleteDiseaseCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
    }
}