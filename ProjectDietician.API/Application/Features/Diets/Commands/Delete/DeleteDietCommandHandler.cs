using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Commands.Delete {
    public class DeleteDietCommandHandler : IRequestHandler<DeleteDietCommand, BaseResponse<Diet>> {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public DeleteDietCommandHandler (IDietRepository DietRepository, IMapper mapper) {
            _dietRepository = DietRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<Diet>> Handle (DeleteDietCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Diet> () { ReponseName = nameof (DeleteDietCommand), Content = new List<Diet> () { } };
            var entity = await _dietRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Diet)} not found.";
                response.Content = null;
            } else {
                await _dietRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Diet)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}