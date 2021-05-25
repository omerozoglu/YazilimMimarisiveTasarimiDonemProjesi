using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Queries.Get {
    public class GetAdminQuery : IRequest<BaseResponse<Admin>> {
        public GetAdminQuery (string id) {
            this.Id = id;

        }
        public string Id { get; set; }
    }
}