using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Commands.Update {
    public class UpdateFoodCommand : Food, IRequest<BaseResponse<Food>> {

    }
}