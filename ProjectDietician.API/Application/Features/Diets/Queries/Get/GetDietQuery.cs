using Domain.Common;
using Domain.Entities.Diets;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diets.Queries.Get {
    public class GetDietQuery : IRequest<BaseResponse<Diet>> {
        public string Id { get; set; }
        public GetDietQuery (string Id) {
            this.Id = Id;
        }
    }
}