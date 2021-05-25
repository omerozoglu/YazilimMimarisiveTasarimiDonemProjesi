using Application.Contracts;
using Domain.Entities.Persons;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class AdminRepository : MongoDBRepositoryBase<Admin>, IAdminRepository {
        public AdminRepository (AdminMongoContext context) : base (context) {

        }
    }
}