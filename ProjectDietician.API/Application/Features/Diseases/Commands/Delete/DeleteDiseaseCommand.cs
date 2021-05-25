using Domain.Common;
using Domain.Entities.Diets;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Commands.Delete {
    public class DeleteDiseaseCommand : IRequest<BaseResponse<Disease>> {
        public string Id { get; set; }
    }
}