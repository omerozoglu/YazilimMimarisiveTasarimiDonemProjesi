using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Commands.Update {
    public class UpdateDietCommand : Diet, IRequest<BaseResponse<Diet>> {

    }
}