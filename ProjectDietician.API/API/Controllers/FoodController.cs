using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Foods.Commands.Create;
using Application.Features.Foods.Commands.Delete;
using Application.Features.Foods.Commands.Update;
using Application.Features.Foods.Queries.Get;
using Application.Features.Foods.Queries.GetList;
using Application.Features.Foods.Queries.GetListByTag;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/v1/[controller]")]
    public class FoodController : Controller {
        private readonly IMediator _mediator;

        public FoodController (IMediator mediator) {
            _mediator = mediator;
        }

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
    }
}