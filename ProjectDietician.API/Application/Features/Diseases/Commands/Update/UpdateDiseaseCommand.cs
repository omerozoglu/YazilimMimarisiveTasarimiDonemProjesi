using Domain.Common;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Commands.Update {
    public class UpdateDiseaseCommand : Disease, IRequest<BaseResponse<Disease>> {

    }
}