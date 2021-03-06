using Application.Contracts;
using Domain.Entities.Persons;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class DieticianRepository : MongoDBRepositoryBase<Dietician>, IDieticianRepository {
        public DieticianRepository (DieticianMongoContext context) : base (context) {

        }
    }
}