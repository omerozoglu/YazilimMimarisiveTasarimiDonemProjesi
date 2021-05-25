using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Commands.Update {
    public class UpdatePatientCommand : Patient, IRequest<BaseResponse<Patient>> {

    }
}