using System.Collections.Generic;
using Domain.Common;
using Domain.Entities.Diets;

namespace Domain.Entities.Persons {
    public class Patient : Person {
        public string DietId { get; set; }
        public string DieticianId { get; set; }
        public List<string> DiseaseIds { get; set; }
    }
}