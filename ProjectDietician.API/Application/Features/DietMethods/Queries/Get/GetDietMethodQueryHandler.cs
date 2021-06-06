using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Queries.Get {
    public class GetDietMethodQueryHandler : IRequestHandler<GetDietMethodQuery, BaseResponse<DietMethod>> {
        private readonly IDietMethodRepository _dietMethodRepository;
        private readonly IMapper _mapper;

        public GetDietMethodQueryHandler (IDietMethodRepository dietMethodRepository, IMapper mapper) {
            _dietMethodRepository = dietMethodRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DietMethod>> Handle (GetDietMethodQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<DietMethod> () { ReponseName = nameof (GetDietMethodQuery), Content = new List<DietMethod> () { } };
            var entity = await _dietMethodRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<DietMethod> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(DietMethod)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(DietMethod)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}