using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Queries.Get {
    public class GetDieticianQuery : IRequest<BaseResponse<Dietician>> {
        public GetDieticianQuery (string id) {
            this.Id = id;

        }
        public string Id { get; set; }
    }
}