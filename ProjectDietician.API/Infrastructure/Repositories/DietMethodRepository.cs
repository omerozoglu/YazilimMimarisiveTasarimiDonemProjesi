using Application.Contracts;
using Domain.Entities.Diets;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class DietMethodRepository : MongoDBRepositoryBase<DietMethod>, IDietMethodRepository {
        public DietMethodRepository (DietMethodMongoContext context) : base (context) {

        }
    }
}