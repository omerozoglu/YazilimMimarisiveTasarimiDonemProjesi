using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Commands.Delete {
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, BaseResponse<Food>> {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public DeleteFoodCommandHandler (IFoodRepository foodRepository, IMapper mapper) {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<Food>> Handle (DeleteFoodCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Food> () { ReponseName = nameof (DeleteFoodCommand), Content = new List<Food> () { } };
            var entity = await _foodRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Food)} not found.";
                response.Content = null;
            } else {
                await _foodRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Food)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}