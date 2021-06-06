using Domain.Entities.Diets;
using Infrastructure.Utilities.AppSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence {
    public class DietMethodMongoContext : IMongoContext<DietMethod> {
        //* MongoDbContext, MongoDb için gerekli ayarlamaları yapması ve asenkron bir şekilde komutları yürüttmesi için tasarlanmıştır

        #region MongoDb
        public IMongoCollection<DietMethod> Collection { get; }
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        public CollectionNames _collectionNames = CollectionNames.DietMethodCollection;
        #endregion

        #region Settings
        private readonly MongoDbSettings _settings;

        #endregion

        public DietMethodMongoContext (IOptions<MongoDbSettings> options) {
            this._settings = options.Value;
            _mongoClient = new MongoClient (this._settings.ConnectionString);
            _database = _mongoClient.GetDatabase (this._settings.DatabaseName);
            Collection = _database.GetCollection<DietMethod> (_collectionNames.Value);
        }
    }
}