using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Commands.Create {
    public class CreateDietMethodCommand : DietMethod, IRequest<BaseResponse<DietMethod>> {

    }
}