using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Queries.GetList {
    public class GetListDietQuery : IRequest<BaseResponse<Diet>> {

    }
}