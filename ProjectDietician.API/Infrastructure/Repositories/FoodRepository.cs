using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Entities.Diets;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories {
    public class FoodRepository : MongoDBRepositoryBase<Food>, IFoodRepository {
        public FoodRepository (FoodMongoContext context) : base (context) {

        }

        public async Task<List<Food>> GetListByTagsAsync (string tag) {
            List<Food> response = new List<Food> ();
            response = await _context.Collection.Find (p => true).ToListAsync ();
            foreach (var item in response) {
                var foods = item.Tag;
            }
            return response;
        }
    }
}