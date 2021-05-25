using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Queries.Get {
    public class GetDiseaseQueryHandler : IRequestHandler<GetDiseaseQuery, BaseResponse<Disease>> {
        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IMapper _mapper;

        public GetDiseaseQueryHandler (IDiseaseRepository diseaseRepository, IMapper mapper) {
            _diseaseRepository = diseaseRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Disease>> Handle (GetDiseaseQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Disease> () { ReponseName = nameof (GetDiseaseQuery), Content = new List<Disease> () { } };
            var entity = await _diseaseRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<Disease> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Disease)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Disease)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}