using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Queries.Get {
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, BaseResponse<Patient>> {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetPatientQueryHandler (IPatientRepository patientRepository, IMapper mapper) {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Patient>> Handle (GetPatientQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Patient> () { ReponseName = nameof (GetPatientQuery), Content = new List<Patient> () { } };
            var entity = await _patientRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<Patient> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Patient)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Patient)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}