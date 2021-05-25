using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Queries.GetList {
    public class GetListPatientQuery : IRequest<BaseResponse<Patient>> {

    }
}