using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Delete;
using Application.Features.Admins.Commands.Update;
using Application.Features.Admins.Queries.Get;
using Application.Features.Admins.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using Domain.Entities.Diseases;
using Domain.Entities.Persons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {

    [ApiController]

    [Route ("api/v1/[controller]")]
    public class AdminController : Controller {
        private readonly IMediator _mediator;

        public AdminController (IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [Route ("Admin")]
        [ProducesResponseType (typeof (BaseResponse<Admin>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Admin>>> GetAdmins () {
            var query = new GetListAdminQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpGet]
        [Route ("Admin/{id:length(24)}")]
        [ProducesResponseType (typeof (BaseResponse<Admin>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Admin>>> GetAdmin (string id) {
            var query = new GetAdminQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpPost]
        [Route ("Admin")]
        [ProducesResponseType (typeof (BaseResponse<Admin>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Admin>>> CreateAdmin (CreateAdminCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Admin> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpPut]
        [Route ("Admin")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Admin>>> UpdateAdmin (UpdateAdminCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Admin> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpDelete]
        [Route ("Admin")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Admin>>> DeleteAdmin (DeleteAdminCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
    }
}