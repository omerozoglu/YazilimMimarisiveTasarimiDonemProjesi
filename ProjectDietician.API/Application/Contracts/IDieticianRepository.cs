using Domain.Entities.Persons;

namespace Application.Contracts {
    public interface IDieticianRepository : IAsyncRepository<Dietician> {
        //* Diyetisyene özel veritabanı işlemleri
    }
}