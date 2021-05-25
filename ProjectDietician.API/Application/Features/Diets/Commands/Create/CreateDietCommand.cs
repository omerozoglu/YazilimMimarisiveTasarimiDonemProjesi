using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Commands.Create {
    public class CreateDietCommand : Diet, IRequest<BaseResponse<Diet>> {

    }
}