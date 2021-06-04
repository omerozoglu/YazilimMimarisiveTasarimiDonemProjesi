using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities.Diets {
    public class DietMethod : EntityBase {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> FoodIds { get; set; }
    }
}