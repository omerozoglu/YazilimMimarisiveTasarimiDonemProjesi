using Application.Contracts;
using Domain.Entities.Diets;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class DietRepository : MongoDBRepositoryBase<Diet>, IDietRepository {
        public DietRepository (DietMongoContext context) : base (context) {

        }
    }
}