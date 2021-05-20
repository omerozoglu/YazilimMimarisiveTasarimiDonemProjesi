using System.Collections.Generic;
using Domain.Common;
using Domain.Entities.Diets.Enums;

namespace Domain.Entities.Diets {
    public class Food : EntityBase {
        public string Name { get; set; }
        public List<string> Tag { get; set; }
        public FoodTime FoodTime { get; set; }
    }
}