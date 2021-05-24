using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Commands.Delete {
    public class DeleteFoodCommand : Food, IRequest<BaseResponse<Food>> { }
}