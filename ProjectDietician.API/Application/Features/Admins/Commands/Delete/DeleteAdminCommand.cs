using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Admins.Commands.Delete {
    public class DeleteAdminCommand : IRequest<BaseResponse<Admin>> {
        public string Id { get; set; }
    }
}