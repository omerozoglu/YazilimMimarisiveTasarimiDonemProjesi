using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Commands.Update {
    public class UpdateAdminCommand : Admin, IRequest<BaseResponse<Admin>> {

    }
}