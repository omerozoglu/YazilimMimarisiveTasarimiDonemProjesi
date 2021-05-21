using System.Collections.Generic;
using Domain.Common;
using Domain.Entities.Diets;
using Domain.Entities.Diseases;

namespace Domain.Entities.Persons {
    public class Patient : Person {
        public Diet Diet { get; set; }
        public Dietician Dietician { get; set; }
        public List<Disease> Diseases { get; set; }
    }
}