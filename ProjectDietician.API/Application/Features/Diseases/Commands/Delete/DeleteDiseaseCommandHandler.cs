using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Commands.Delete {
    public class DeleteDiseaseCommandHandler : IRequestHandler<DeleteDiseaseCommand, BaseResponse<Disease>> {

        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IMapper _mapper;

        public DeleteDiseaseCommandHandler (IDiseaseRepository diseaseRepository, IMapper mapper) {
            _diseaseRepository = diseaseRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Disease>> Handle (DeleteDiseaseCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Disease> () { ReponseName = nameof (DeleteDiseaseCommand), Content = new List<Disease> () { } };
            var entity = await _diseaseRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Disease)} not found.";
                response.Content = null;
            } else {
                await _diseaseRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Disease)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}