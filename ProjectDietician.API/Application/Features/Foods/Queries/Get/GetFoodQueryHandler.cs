using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Queries.Get {
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, BaseResponse<Food>> {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public GetFoodQueryHandler (IFoodRepository foodRepository, IMapper mapper) {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Food>> Handle (GetFoodQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Food> () { ReponseName = nameof (GetFoodQuery), Content = new List<Food> () { } };
            var entity = await _foodRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<Food> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Food)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Food)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}