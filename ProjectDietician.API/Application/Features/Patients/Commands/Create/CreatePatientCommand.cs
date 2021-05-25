using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Commands.Create {
    public class CreatePatientCommand : Patient, IRequest<BaseResponse<Patient>> {

    }
}