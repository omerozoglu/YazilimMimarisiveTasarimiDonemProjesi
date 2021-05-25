using System.Collections.Generic;
using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Queries.GetListByTag {
    public class GetListByTag : IRequest<BaseResponse<Food>> {
        public GetListByTag (string tag) {
            Tag = tag;
        }

        public string Tag { get; set; }
    }
}