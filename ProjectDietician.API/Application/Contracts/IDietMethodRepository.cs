using Domain.Entities.Diets;

namespace Application.Contracts {
    public interface IDietMethodRepository : IAsyncRepository<DietMethod> {
        //* DietMethod özel veritabanı işlemleri
    }
}