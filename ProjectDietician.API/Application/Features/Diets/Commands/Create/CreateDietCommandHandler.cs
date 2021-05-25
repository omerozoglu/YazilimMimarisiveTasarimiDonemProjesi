using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Commands.Create {
    public class CreateDietCommandHandler : IRequestHandler<CreateDietCommand, BaseResponse<Diet>> {

        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public CreateDietCommandHandler (IDietRepository DietRepository, IMapper mapper) {
            _dietRepository = DietRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Diet>> Handle (CreateDietCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Diet> { ReponseName = nameof (CreateDietCommand), Content = new List<Diet> () { } };
            var entity = _mapper.Map<Diet> (request);
            var newentity = await _dietRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Diet)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Diet)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}