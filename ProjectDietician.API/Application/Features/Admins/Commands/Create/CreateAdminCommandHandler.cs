using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Commands.Create {
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, BaseResponse<Admin>> {

        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public CreateAdminCommandHandler (IAdminRepository adminRepository, IMapper mapper) {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Admin>> Handle (CreateAdminCommand request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Admin> { ReponseName = nameof (CreateAdminCommand), Content = new List<Admin> () { } };
            var entity = _mapper.Map<Admin> (request);
            var newentity = await _adminRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Admin)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Admin)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}