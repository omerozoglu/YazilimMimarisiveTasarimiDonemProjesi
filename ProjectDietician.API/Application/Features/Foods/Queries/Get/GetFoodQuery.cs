using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Queries.Get {
    public class GetFoodQuery : IRequest<BaseResponse<Food>> {
        public string Id { get; set; }
        public GetFoodQuery (string Id) {
            this.Id = Id;
        }
    }
}