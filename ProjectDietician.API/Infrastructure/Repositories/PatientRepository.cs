using Application.Contracts;
using Domain.Entities.Persons;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class PatientRepository : MongoDBRepositoryBase<Patient>, IPatientRepository {
        public PatientRepository (IMongoContext<Patient> context) : base (context) {

        }
    }
}