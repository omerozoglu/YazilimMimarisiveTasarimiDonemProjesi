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

        public async Task<List<Food>> GetListByTagsAsync (string Tag) {
            List<Food> response = new List<Food> ();
            List<Food> foods = new List<Food> ();
            foods = await _context.Collection.Find (p => true).ToListAsync ();
            foreach (var food in foods) {
                List<string> tags = food.Tag;
                foreach (var tag in tags) {
                    if (tag == Tag) {
                        response.Add (food);
                        break;
                    }
                }
            }
            return response;
        }
    }
}