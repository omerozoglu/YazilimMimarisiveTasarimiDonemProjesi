using Domain.Entities.Diseases;

namespace Application.Contracts {
    public interface IDiseaseRepository : IAsyncRepository<Disease> {
        //* Hastalığa özel veri tabanı işlemleri
    }
}