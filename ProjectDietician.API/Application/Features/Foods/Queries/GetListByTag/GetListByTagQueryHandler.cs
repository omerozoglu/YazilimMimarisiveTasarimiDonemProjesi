using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Queries.GetListByTag {
    public class GetListByTagQueryHandler : IRequestHandler<GetListByTag, BaseResponse<Food>> {

        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public GetListByTagQueryHandler (IFoodRepository foodRepository, IMapper mapper) {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Food>> Handle (GetListByTag request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Food> () { ReponseName = nameof (GetListByTag), Content = new List<Food> () { } };
            var entity = await _foodRepository.GetListByTagsAsync (request.Tag);
            entity = _mapper.Map<List<Food>> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Food)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Food)} get successfully.";
                response.Content.AddRange (entity);
            }
            return response;
        }
    }
}