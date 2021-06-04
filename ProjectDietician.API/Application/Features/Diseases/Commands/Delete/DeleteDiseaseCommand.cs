using Domain.Common;
using Domain.Entities.Diets;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Commands.Delete {
    public class DeleteDiseaseCommand : IRequest<BaseResponse<Disease>> {
        public DeleteDiseaseCommand (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}