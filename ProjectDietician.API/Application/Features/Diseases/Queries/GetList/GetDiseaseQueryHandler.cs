using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Queries.GetList {
    public class GetDisaseQueryHandler : IRequestHandler<GetListDisaseQuery, BaseResponse<Disease>> {
        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IMapper _mapper;

        public GetDisaseQueryHandler (IDiseaseRepository diseaseRepository, IMapper mapper) {
            _diseaseRepository = diseaseRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<Disease>> Handle (GetListDisaseQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Disease> () { ReponseName = nameof (GetListDisaseQuery), Content = new List<Disease> () { } };
            var entity = await _diseaseRepository.GetAllAsync ();
            entity = _mapper.Map<List<Disease>> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Disease)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Disease)} get successfully.";
                response.Content.AddRange (entity);
            }
            return response;
        }
    }
}