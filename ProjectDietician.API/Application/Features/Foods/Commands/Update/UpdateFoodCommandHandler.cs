using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Commands.Update {
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, BaseResponse<Food>> {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public UpdateFoodCommandHandler (IFoodRepository foodRepository, IMapper mapper) {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Food>> Handle (UpdateFoodCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Food> () { ReponseName = nameof (UpdateFoodCommand), Content = new List<Food> () { } };
            var entity = await _foodRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Food)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateFoodCommand), typeof (Food));
                await _foodRepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Food)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}