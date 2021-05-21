using Domain.Entities.Persons;

namespace Application.Contracts {
    public interface IAdminRepository : IAsyncRepository<Admin> {
        //* Admin özel veritabanı işlemleri
    }
}