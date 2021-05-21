using Domain.Entities.Diets;

namespace Application.Contracts {
    public interface IDietRepository : IAsyncRepository<Diet> {
        //* Diete özel veritabanı işlemleri
    }
}