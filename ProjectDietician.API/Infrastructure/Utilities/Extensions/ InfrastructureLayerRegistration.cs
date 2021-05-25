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

            services.AddScoped<AdminMongoContext> ();
            services.AddScoped<IAdminRepository, AdminRepository> ();

            services.AddScoped<DieticianMongoContext> ();
            services.AddScoped<IDieticianRepository, DieticianRepository> ();

            services.AddScoped<PatientMongoContext> ();
            services.AddScoped<IPatientRepository, PatientRepository> ();

            services.AddScoped<DietMongoContext> ();
            services.AddScoped<IDietRepository, DietRepository> ();

            services.AddScoped<FoodMongoContext> ();
            services.AddScoped<IFoodRepository, FoodRepository> ();

            services.AddScoped<DiseaseMongoContext> ();
            services.AddScoped<IDiseaseRepository, DiseaseRepository> ();

            services.AddScoped (typeof (IAsyncRepository<>), typeof (MongoDBRepositoryBase<>));
            return services;
        }
    }
}