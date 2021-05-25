using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Queries.Get {
    public class GetDietQueryHandler : IRequestHandler<GetDietQuery, BaseResponse<Diet>> {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetDietQueryHandler (IDietRepository DietRepository, IMapper mapper) {
            _dietRepository = DietRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Diet>> Handle (GetDietQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Diet> () { ReponseName = nameof (GetDietQuery), Content = new List<Diet> () { } };
            var entity = await _dietRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<Diet> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Diet)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Diet)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}