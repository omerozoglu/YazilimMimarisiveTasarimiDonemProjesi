using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Diets;

namespace Application.Contracts {
    public interface IFoodRepository : IAsyncRepository<Food> {
        //* Yemeğe özel veritabanı işlemleri
        Task<Food> GetByTagsAsync (List<string> tags);
    }
}