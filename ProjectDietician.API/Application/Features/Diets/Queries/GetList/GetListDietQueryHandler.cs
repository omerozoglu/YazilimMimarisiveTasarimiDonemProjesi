using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Diets.Queries.GetList {
    public class GetListDietQueryHandler : IRequestHandler<GetListDietQuery, BaseResponse<Diet>> {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetListDietQueryHandler (IDietRepository DietRepository, IMapper mapper) {
            _dietRepository = DietRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Diet>> Handle (GetListDietQuery request, CancellationToken cancellationToken) {
            var response = new BaseResponse<Diet> () { ReponseName = nameof (GetListDietQuery), Content = new List<Diet> () { } };
            var entity = await _dietRepository.GetAllAsync ();
            entity = _mapper.Map<List<Diet>> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(Diet)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Diet)} get successfully.";
                response.Content.AddRange (entity);
            }
            return response;
        }
    }
}