using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Patients.Commands.Create;
using Application.Features.Patients.Commands.Delete;
using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Queries.Get;
using Application.Features.Patients.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {

    [ApiController]
    [Route ("api/v1/[controller]")]
    public class PatientController : Controller {
        private readonly IMediator _mediator;

        public PatientController (IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [Route ("Patient")]
        [ProducesResponseType (typeof (BaseResponse<Patient>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Patient>>> GetPatients () {
            var query = new GetListPatientQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpGet]
        [Route ("Patient/{id:length(24)}")]
        [ProducesResponseType (typeof (BaseResponse<Patient>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Patient>>> GetPatient (string id) {
            var query = new GetPatientQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpPost]
        [Route ("Patient")]
        [ProducesResponseType (typeof (BaseResponse<Patient>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Patient>>> CreatePatient (CreatePatientCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Patient> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpPut]
        [Route ("Patient")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Patient>>> UpdatePatient (UpdatePatientCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Patient> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpDelete]
        [Route ("Patient")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Patient>>> DeletePatient (DeletePatientCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
    }
}