using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Features.Admins.Commands.Delete;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Commands.Delete {
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, BaseResponse<Admin>> {
        private readonly IAdminRepository _adminRepository;
        //private readonly IMapper _mapper;

        public DeleteAdminCommandHandler (IAdminRepository adminRepository, IMapper mapper) {
            _adminRepository = adminRepository;
            //  _mapper = mapper;
        }
        public async Task<BaseResponse<Admin>> Handle (DeleteAdminCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Admin> () { ReponseName = nameof (DeleteAdminCommand), Content = new List<Admin> () { } };
            var entity = await _adminRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Admin)} not found.";
                response.Content = null;
            } else {
                await _adminRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Admin)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}