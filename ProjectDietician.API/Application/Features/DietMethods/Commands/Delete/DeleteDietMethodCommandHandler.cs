using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Commands.Delete {
    public class DeleteDietMethodCommandHandler : IRequestHandler<DeleteDietMethodCommand, BaseResponse<DietMethod>> {
        private readonly IDietMethodRepository _dietMethodRepository;
        private readonly IMapper _mapper;

        public DeleteDietMethodCommandHandler (IDietMethodRepository dietMethodRepository, IMapper mapper) {
            _dietMethodRepository = dietMethodRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<DietMethod>> Handle (DeleteDietMethodCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<DietMethod> () { ReponseName = nameof (DeleteDietMethodCommand), Content = new List<DietMethod> () { } };
            var entity = await _dietMethodRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(DietMethod)} not found.";
                response.Content = null;
            } else {
                await _dietMethodRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(DietMethod)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}