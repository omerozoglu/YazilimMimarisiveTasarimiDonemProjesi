using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Commands.Create {
    public class CreateDiseaseCommandHandler : IRequestHandler<CreateDiseaseCommand, BaseResponse<Disease>> {

        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IMapper _mapper;

        public CreateDiseaseCommandHandler (IDiseaseRepository diseaseRepository, IMapper mapper) {
            _diseaseRepository = diseaseRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Disease>> Handle (CreateDiseaseCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Disease> { ReponseName = nameof (CreateDiseaseCommand), Content = new List<Disease> () { } };
            var entity = _mapper.Map<Disease> (request);
            var newentity = await _diseaseRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Disease)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Disease)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}