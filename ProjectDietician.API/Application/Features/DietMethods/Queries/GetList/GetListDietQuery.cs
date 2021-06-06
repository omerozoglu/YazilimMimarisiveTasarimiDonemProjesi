using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Queries.GetList {
    public class GetListDietMethodQuery : IRequest<BaseResponse<DietMethod>> {

    }
}