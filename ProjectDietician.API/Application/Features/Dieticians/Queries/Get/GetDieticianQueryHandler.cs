using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Queries.Get {
    public class GetDieticianQueryHandler : IRequestHandler<GetDieticianQuery, BaseResponse<Dietician>> {
        private readonly IDieticianRepository _dieticianRepository;
        private readonly IMapper _mapper;

        public GetDieticianQueryHandler (IDieticianRepository dieticianRepository, IMapper mapper) {
            _dieticianRepository = dieticianRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Dietician>> Handle (GetDieticianQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Dietician> () { ReponseName = nameof (GetDieticianQuery), Content = new List<Dietician> () { } };
            var entity = await _dieticianRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<Dietician> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Dietician)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Dietician)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}