using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Commands.Delete {
    public class DeleteDietMethodCommand : IRequest<BaseResponse<DietMethod>> {
        public string Id { get; set; }
    }
}