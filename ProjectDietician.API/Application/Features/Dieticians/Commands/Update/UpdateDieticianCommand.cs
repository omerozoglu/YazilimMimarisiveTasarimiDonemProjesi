using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Commands.Update {
    public class UpdateDieticianCommand : Dietician, IRequest<BaseResponse<Dietician>> {

    }
}