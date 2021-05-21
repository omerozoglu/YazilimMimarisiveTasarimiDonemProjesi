using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities.Diets {
    public class DietMethod : EntityBase {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public List<Food> Content { get; protected set; }
    }
}