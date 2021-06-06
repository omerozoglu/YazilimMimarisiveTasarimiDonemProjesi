using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Queries.GetList {
    public class GetListDietMethodQueryHandler : IRequestHandler<GetListDietMethodQuery, BaseResponse<DietMethod>> {
        private readonly IDietMethodRepository _dietMethodRepository;
        private readonly IMapper _mapper;

        public GetListDietMethodQueryHandler (IDietMethodRepository dietMethodRepository, IMapper mapper) {
            _dietMethodRepository = dietMethodRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DietMethod>> Handle (GetListDietMethodQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<DietMethod> () { ReponseName = nameof (GetListDietMethodQuery), Content = new List<DietMethod> () { } };
            var entity = await _dietMethodRepository.GetAllAsync ();
            entity = _mapper.Map<List<DietMethod>> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(DietMethod)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(DietMethod)} get successfully.";
                response.Content.AddRange (entity);
            }
            return response;
        }
    }
}