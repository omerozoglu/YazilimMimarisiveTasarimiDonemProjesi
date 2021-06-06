using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Commands.Update {
    public class UpdateDietMethodCommand : DietMethod, IRequest<BaseResponse<DietMethod>> {

    }
}