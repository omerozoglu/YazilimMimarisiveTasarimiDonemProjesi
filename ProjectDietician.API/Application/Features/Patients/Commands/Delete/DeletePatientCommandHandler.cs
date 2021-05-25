using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Commands.Delete {
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, BaseResponse<Patient>> {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public DeletePatientCommandHandler (IPatientRepository patientRepository, IMapper mapper) {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Patient>> Handle (DeletePatientCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Patient> () { ReponseName = nameof (DeletePatientCommand), Content = new List<Patient> () { } };
            var entity = await _patientRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Patient)} not found.";
                response.Content = null;
            } else {
                await _patientRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Patient)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}