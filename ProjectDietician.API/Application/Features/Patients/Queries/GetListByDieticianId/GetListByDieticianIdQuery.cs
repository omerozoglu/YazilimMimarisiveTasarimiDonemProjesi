using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Queries.GetListByDieticianId {
    public class GetListByDieticianIdQuery : IRequest<BaseResponse<Patient>> {
        public GetListByDieticianIdQuery (string id) {
            this.dieticianId = id;

        }
        public string dieticianId { get; set; }
    }
}