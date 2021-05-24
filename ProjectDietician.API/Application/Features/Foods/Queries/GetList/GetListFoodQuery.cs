using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Queries.GetList {
    public class GetListFoodQuery : IRequest<BaseResponse<Food>> {
        //* tamamını çağırdığım için herhangi bir özelllik eklemiyorum
    }
}