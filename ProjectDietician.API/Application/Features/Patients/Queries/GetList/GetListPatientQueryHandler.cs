using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Queries.GetList {
    public class GetListPatientQueryHandler : IRequestHandler<GetListPatientQuery, BaseResponse<Patient>> {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetListPatientQueryHandler (IPatientRepository patientRepository, IMapper mapper) {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Patient>> Handle (GetListPatientQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Patient> () { ReponseName = nameof (GetListPatientQuery), Content = new List<Patient> () { } };
            var entity = await _patientRepository.GetAllAsync ();
            entity = _mapper.Map<List<Patient>> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Patient)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Patient)} get successfully.";
                response.Content.AddRange (entity);
            }
            return response;
        }
    }
}