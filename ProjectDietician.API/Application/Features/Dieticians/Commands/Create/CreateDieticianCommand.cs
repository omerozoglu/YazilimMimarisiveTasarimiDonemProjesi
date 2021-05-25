using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Commands.Create {
    public class CreateDieticianCommand : Dietician, IRequest<BaseResponse<Dietician>> {

    }
}