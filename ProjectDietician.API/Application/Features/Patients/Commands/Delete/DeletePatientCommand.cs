using Domain.Common;
using Domain.Entities.Diets;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Commands.Delete {
    public class DeletePatientCommand : IRequest<BaseResponse<Patient>> {
        public string Id { get; set; }
    }
}