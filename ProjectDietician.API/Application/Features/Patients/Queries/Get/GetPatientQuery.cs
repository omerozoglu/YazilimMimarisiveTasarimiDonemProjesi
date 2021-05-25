using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Queries.Get {
    public class GetPatientQuery : IRequest<BaseResponse<Patient>> {
        public GetPatientQuery (string id) {
            this.Id = id;

        }
        public string Id { get; set; }
    }
}