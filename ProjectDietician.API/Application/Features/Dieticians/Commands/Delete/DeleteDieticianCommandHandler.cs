using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Commands.Delete {
    public class DeleteDieticianCommandHandler : IRequestHandler<DeleteDieticianCommand, BaseResponse<Dietician>> {
        private readonly IDieticianRepository _dieticianRepository;
        private readonly IMapper _mapper;

        public DeleteDieticianCommandHandler (IDieticianRepository dieticianRepository, IMapper mapper) {
            _dieticianRepository = dieticianRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Dietician>> Handle (DeleteDieticianCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Dietician> () { ReponseName = nameof (DeleteDieticianCommand), Content = new List<Dietician> () { } };
            var entity = await _dieticianRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Dietician)} not found.";
                response.Content = null;
            } else {
                await _dieticianRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Dietician)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}