using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Commands.Create {
    public class CreateDieticianCommandHandler : IRequestHandler<CreateDieticianCommand, BaseResponse<Dietician>> {

        private readonly IDieticianRepository _dieticianRepository;
        private readonly IMapper _mapper;

        public CreateDieticianCommandHandler (IDieticianRepository dieticianRepository, IMapper mapper) {
            _dieticianRepository = dieticianRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Dietician>> Handle (CreateDieticianCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Dietician> { ReponseName = nameof (CreateDieticianCommand), Content = new List<Dietician> () { } };
            var entity = _mapper.Map<Dietician> (request);
            var newentity = await _dieticianRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(Dietician)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Dietician)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}