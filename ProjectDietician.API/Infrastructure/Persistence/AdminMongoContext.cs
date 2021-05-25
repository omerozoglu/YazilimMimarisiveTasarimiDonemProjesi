using Domain.Entities.Persons;
using Infrastructure.Utilities.AppSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence {
    public class AdminMongoContext : IMongoContext<Admin> {
        //* MongoDbContext, MongoDb için gerekli ayarlamaları yapması ve asenkron bir şekilde komutları yürüttmesi için tasarlanmıştır

        #region MongoDb
        public IMongoCollection<Admin> Collection { get; }
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        public CollectionNames _collectionNames = CollectionNames.AdminCollection;
        #endregion

        #region Settings
        private readonly MongoDbSettings _settings;

        #endregion

        public AdminMongoContext (IOptions<MongoDbSettings> options) {
            this._settings = options.Value;
            _mongoClient = new MongoClient (this._settings.ConnectionString);
            _database = _mongoClient.GetDatabase (this._settings.DatabaseName);
            Collection = _database.GetCollection<Admin> (_collectionNames.Value);
        }
    }
}