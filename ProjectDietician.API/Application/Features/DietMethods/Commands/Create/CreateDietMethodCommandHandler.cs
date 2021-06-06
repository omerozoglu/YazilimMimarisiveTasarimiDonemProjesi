using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Commands.Create {
    public class CreateDietMethodCommandHandler : IRequestHandler<CreateDietMethodCommand, BaseResponse<DietMethod>> {

        private readonly IDietMethodRepository _dietMethodRepository;
        private readonly IMapper _mapper;

        public CreateDietMethodCommandHandler (IDietMethodRepository dietMethodRepository, IMapper mapper) {
            _dietMethodRepository = dietMethodRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DietMethod>> Handle (CreateDietMethodCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<DietMethod> { ReponseName = nameof (CreateDietMethodCommand), Content = new List<DietMethod> () { } };
            var entity = _mapper.Map<DietMethod> (request);
            var newentity = await _dietMethodRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(DietMethod)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(DietMethod)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}