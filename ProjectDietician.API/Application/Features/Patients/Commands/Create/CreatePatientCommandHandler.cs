using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Commands.Create {
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, BaseResponse<Patient>> {

        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler (IPatientRepository patientRepository, IMapper mapper) {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Patient>> Handle (CreatePatientCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Patient> () { ReponseName = nameof (CreatePatientCommand), Content = new List<Patient> () { } };
            var entity = _mapper.Map<Patient> (request);
            var newentity = await _patientRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Patient)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Patient)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}