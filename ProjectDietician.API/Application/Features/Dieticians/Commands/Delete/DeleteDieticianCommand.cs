using Domain.Common;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Features.Dieticians.Commands.Delete {
    public class DeleteDieticianCommand : IRequest<BaseResponse<Dietician>> {
        public string Id { get; set; }
    }
}