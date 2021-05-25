using Application.Contracts;
using Domain.Entities.Diets;
using Domain.Entities.Diseases;
using Domain.Entities.Persons;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Utilites.Extensions.StartupExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure {
    public static class InfrastructureServiceRegistration {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration) {
            services.AddMongoDbSettings (configuration);

            services.AddScoped<MongoContext<Admin>> ();
            services.AddScoped<IAdminRepository, AdminRepository> ();

            services.AddScoped<MongoContext<Dietician>> ();
            services.AddScoped<IDieticianRepository, DieticianRepository> ();

            services.AddScoped<MongoContext<Patient>> ();
            services.AddScoped<IPatientRepository, PatientRepository> ();

            services.AddScoped<MongoContext<Diet>> ();
            services.AddScoped<IDietRepository, DietRepository> ();

            services.AddScoped<MongoContext<Food>> ();
            services.AddScoped<IFoodRepository, FoodRepository> ();

            services.AddScoped<MongoContext<Disease>> ();
            services.AddScoped<IDiseaseRepository, DiseaseRepository> ();

            services.AddScoped (typeof (IAsyncRepository<>), typeof (MongoDBRepositoryBase<>));
            return services;
        }
    }
}