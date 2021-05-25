using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Entities.Diets;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories {
    public class FoodRepository : MongoDBRepositoryBase<Food>, IFoodRepository {
        public FoodRepository (IMongoContext<Food> context) : base (context) {

        }

        public async Task<List<Food>> GetListByTagsAsync (string tag) {
            List<Food> response = new List<Food> ();
            response = await _context.Collection.Find (p => p.Tag.Find (t => t == tag) != null).ToListAsync ();
            return response;
        }
    }
}