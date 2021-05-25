using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Commands.Update {
    public class UpdateDiseaseCommandHandler : IRequestHandler<UpdateDiseaseCommand, BaseResponse<Disease>> {
        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IMapper _mapper;

        public UpdateDiseaseCommandHandler (IDiseaseRepository diseaseRepository, IMapper mapper) {
            _diseaseRepository = diseaseRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Disease>> Handle (UpdateDiseaseCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Disease> () { ReponseName = nameof (UpdateDiseaseCommand), Content = new List<Disease> () { } };
            var entity = await _diseaseRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Disease)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateDiseaseCommand), typeof (Disease));
                await _diseaseRepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Disease)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}