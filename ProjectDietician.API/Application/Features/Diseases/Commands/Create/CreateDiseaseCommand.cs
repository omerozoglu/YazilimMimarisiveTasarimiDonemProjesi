using Domain.Common;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Commands.Create {
    public class CreateDiseaseCommand : Disease, IRequest<BaseResponse<Disease>> {

    }
}