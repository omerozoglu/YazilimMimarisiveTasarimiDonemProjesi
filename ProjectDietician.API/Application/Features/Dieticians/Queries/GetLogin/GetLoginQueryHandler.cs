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
    public class GetLoginQueryHandler : IRequestHandler<GetLoginQuery, BaseResponse<Dietician>> {
        private readonly IDieticianRepository _dieticianRepository;
        private readonly IMapper _mapper;

        public GetLoginQueryHandler (IDieticianRepository dieticianRepository, IMapper mapper) {
            _dieticianRepository = dieticianRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Dietician>> Handle (GetLoginQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Dietician> () { ReponseName = nameof (GetLoginQuery), Content = new List<Dietician> () { } };
            var entity = await _dieticianRepository.GetOneAsync (p => (p.Username == request.username) && (p.Password == request.password));
            entity = _mapper.Map<Dietician> (entity);
            if (entity == null) {
                response.Status = ResponseType.Warning;
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