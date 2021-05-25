using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Commands.Create {
    public class CreateAdminCommand : Admin, IRequest<BaseResponse<Admin>> {

    }
}