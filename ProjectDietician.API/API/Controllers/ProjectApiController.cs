using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;

#region AdminController
using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Delete;
using Application.Features.Admins.Commands.Update;
using Application.Features.Admins.Queries.Get;
using Application.Features.Admins.Queries.GetList;
#endregion

#region DieticianControllerUsing
using Application.Features.Dieticians.Commands.Create;
using Application.Features.Dieticians.Commands.Delete;
using Application.Features.Dieticians.Commands.Update;
using Application.Features.Dieticians.Queries.Get;
using Application.Features.Dieticians.Queries.GetList;
#endregion

#region PatientControllerUsing
using Application.Features.Patients.Commands.Create;
using Application.Features.Patients.Commands.Delete;
using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Queries.Get;
using Application.Features.Patients.Queries.GetList;
#endregion

#region DietControllerUsing
using Application.Features.Diets.Commands.Create;
using Application.Features.Diets.Commands.Delete;
using Application.Features.Diets.Commands.Update;
using Application.Features.Diets.Queries.Get;
using Application.Features.Diets.Queries.GetList;
#endregion

#region FoodControllerUsing
using Application.Features.Foods.Commands.Create;
using Application.Features.Foods.Commands.Delete;
using Application.Features.Foods.Commands.Update;
using Application.Features.Foods.Queries.Get;
using Application.Features.Foods.Queries.GetList;
using Application.Features.Foods.Queries.GetListByTag;
#endregion

#region DiseaseControllerUsing
using Application.Features.Diseases.Commands.Create;
using Application.Features.Diseases.Commands.Delete;
using Application.Features.Diseases.Commands.Update;
using Application.Features.Diseases.Queries.Get;
using Application.Features.Diseases.Queries.GetList;
#endregion

using System;
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
    public class ProjectApiController : ControllerBase {
        private readonly IMediator _mediator;

        public ProjectApiController (IMediator mediator) {
            _mediator = mediator;
        }

        #region AdminController
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
        #endregion

        #region DieticianController   
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
        #endregion

        #region PatientController
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
        #endregion

        #region DietController
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
        #endregion

        #region FoodController
        [HttpGet]
        [Route ("Food")]
        [ProducesResponseType (typeof (BaseResponse<Food>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Food>>> GetFoods () {
            var query = new GetListFoodQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpGet]
        [Route ("Food/{id:length(24)}")]
        [ProducesResponseType (typeof (BaseResponse<Food>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Food>>> GetFood (string id) {
            var query = new GetFoodQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpGet]
        [Route ("Food/{tag}")]
        [ProducesResponseType (typeof (BaseResponse<Food>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Food>>> GetFoodsByTag (string tag) {
            var query = new GetListByTag (tag);
            var result = await _mediator.Send (query);
            return Ok (result);
        }

        [HttpPost]
        [Route ("Food")]
        [ProducesResponseType (typeof (BaseResponse<Food>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<Food>>> CreateFood (CreateFoodCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Food> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpPut]
        [Route ("Food")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Food>>> UpdateFood (UpdateFoodCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new BaseResponse<Food> ();
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }

        [HttpDelete]
        [Route ("Food")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse<Food>>> DeleteFood (DeleteFoodCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region DiseaseController
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
        #endregion

    }
}