using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Queries.Get {
    public class GetLoginQuery : IRequest<BaseResponse<Dietician>> {
        public string username { get; set; }
        public string password { get; set; }

    }
}