using Domain.Common;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Queries.GetList {
    public class GetListDiseaseQuery : IRequest<BaseResponse<Disease>> {

    }
}