using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Patients.Queries.GetListByDieticianId {
    public class GetListByDieticianIdQueryHandler : IRequestHandler<GetListByDieticianIdQuery, BaseResponse<Patient>> {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetListByDieticianIdQueryHandler (IPatientRepository patientRepository, IMapper mapper) {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Patient>> Handle (GetListByDieticianIdQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Patient> () { ReponseName = nameof (GetListByDieticianIdQuery), Content = new List<Patient> () { } };
            var entity = await _patientRepository.GetAsync (p => p.DieticianId == request.dieticianId);
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