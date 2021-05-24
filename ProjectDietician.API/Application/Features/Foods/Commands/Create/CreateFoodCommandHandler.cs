using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Commands.Create {
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, BaseResponse<Food>> {

        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public CreateFoodCommandHandler (IFoodRepository foodRepository, IMapper mapper) {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Food>> Handle (CreateFoodCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Food> { ReponseName = nameof (CreateFoodCommand), Content = new List<Food> () { } };
            var entity = _mapper.Map<Food> (request);
            var newentity = await _foodRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Food)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Food)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}