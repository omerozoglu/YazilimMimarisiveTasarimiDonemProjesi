using Domain.Common;
using Domain.Entities.Diseases;
using MediatR;

namespace Application.Features.Diseases.Queries.Get {
    public class GetDiseaseQuery : IRequest<BaseResponse<Disease>> {
        public string Id { get; set; }
        public GetDiseaseQuery (string Id) {
            this.Id = Id;
        }
    }
}