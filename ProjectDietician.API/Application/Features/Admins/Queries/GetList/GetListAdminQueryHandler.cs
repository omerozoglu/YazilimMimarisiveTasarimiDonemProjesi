using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Queries.GetList {
    public class GetListAdminQueryHandler : IRequestHandler<GetListAdminQuery, BaseResponse<Admin>> {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetListAdminQueryHandler (IAdminRepository adminRepository, IMapper mapper) {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Admin>> Handle (GetListAdminQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Admin> () { ReponseName = nameof (GetListAdminQuery), Content = new List<Admin> () { } };
            var entity = await _adminRepository.GetAllAsync ();
            entity = _mapper.Map<List<Admin>> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Admin)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Admin)} get successfully.";
                response.Content.AddRange (entity);
            }
            return response;
        }
    }
}