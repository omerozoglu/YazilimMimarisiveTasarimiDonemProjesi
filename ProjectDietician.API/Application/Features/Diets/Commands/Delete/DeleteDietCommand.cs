using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Commands.Delete {
    public class DeleteDietCommand : IRequest<BaseResponse<Diet>> {
        public string Id { get; set; }
    }
}