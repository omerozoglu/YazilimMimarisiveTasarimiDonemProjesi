using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.DietMethods.Queries.Get {
    public class GetDietMethodQuery : IRequest<BaseResponse<DietMethod>> {
        public GetDietMethodQuery (string Id) {
            this.Id = Id;
        }
        public string Id { get; set; }
    }
}