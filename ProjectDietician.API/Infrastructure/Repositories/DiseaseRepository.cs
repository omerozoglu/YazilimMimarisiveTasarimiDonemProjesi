using Application.Contracts;
using Domain.Entities.Diseases;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class DiseaseRepository : MongoDBRepositoryBase<Disease>, IDiseaseRepository {
        public DiseaseRepository (MongoContext<Disease> context) : base (context) {

        }
    }
}