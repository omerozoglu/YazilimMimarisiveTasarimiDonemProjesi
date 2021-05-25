using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Queries.GetList {
    public class GetListDieticianQueryHandler : IRequestHandler<GetListDieticianQuery, BaseResponse<Dietician>> {
        private readonly IDieticianRepository _dieticianRepository;
        private readonly IMapper _mapper;

        public GetListDieticianQueryHandler (IDieticianRepository dieticianRepository, IMapper mapper) {
            _dieticianRepository = dieticianRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Dietician>> Handle (GetListDieticianQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Dietician> () { ReponseName = nameof (GetListDieticianQuery), Content = new List<Dietician> () { } };
            var entity = await _dieticianRepository.GetAllAsync ();
            entity = _mapper.Map<List<Dietician>> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Dietician)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Dietician)} get successfully.";
                response.Content.AddRange (entity);
            }
            return response;
        }
    }
}