using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Queries.GetList {
    public class GetListDieticianQuery : IRequest<BaseResponse<Dietician>> {

    }
}