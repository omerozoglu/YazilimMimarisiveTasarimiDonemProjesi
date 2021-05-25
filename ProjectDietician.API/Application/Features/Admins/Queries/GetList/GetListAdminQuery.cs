using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Queries.GetList {
    public class GetListAdminQuery : IRequest<BaseResponse<Admin>> {

    }
}