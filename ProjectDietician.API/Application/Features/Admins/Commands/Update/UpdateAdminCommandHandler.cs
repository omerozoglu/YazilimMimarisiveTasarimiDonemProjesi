using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Commands.Update {
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, BaseResponse<Admin>> {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public UpdateAdminCommandHandler (IAdminRepository adminRepository, IMapper mapper) {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Admin>> Handle (UpdateAdminCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Admin> () { ReponseName = nameof (UpdateAdminCommand), Content = new List<Admin> () { } };
            var entity = await _adminRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Admin)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateAdminCommand), typeof (Admin));
                await _adminRepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Admin)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}