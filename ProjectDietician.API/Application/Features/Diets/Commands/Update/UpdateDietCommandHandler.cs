using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Commands.Update {
    public class UpdateDietCommandHandler : IRequestHandler<UpdateDietCommand, BaseResponse<Diet>> {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public UpdateDietCommandHandler (IDietRepository DietRepository, IMapper mapper) {
            _dietRepository = DietRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Diet>> Handle (UpdateDietCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Diet> () { ReponseName = nameof (UpdateDietCommand), Content = new List<Diet> () { } };
            var entity = await _dietRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Diet)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateDietCommand), typeof (Diet));
                await _dietRepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Diet)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}