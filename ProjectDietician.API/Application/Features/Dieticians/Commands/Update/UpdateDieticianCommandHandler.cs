using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Commands.Update {
    public class UpdateDieticianCommandHandler : IRequestHandler<UpdateDieticianCommand, BaseResponse<Dietician>> {
        private readonly IDieticianRepository _dieticianRepository;
        private readonly IMapper _mapper;

        public UpdateDieticianCommandHandler (IDieticianRepository dieticianRepository, IMapper mapper) {
            _dieticianRepository = dieticianRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Dietician>> Handle (UpdateDieticianCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Dietician> () { ReponseName = nameof (UpdateDieticianCommand), Content = new List<Dietician> () { } };
            var entity = await _dieticianRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(Dietician)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateDieticianCommand), typeof (Dietician));
                await _dieticianRepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Dietician)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}