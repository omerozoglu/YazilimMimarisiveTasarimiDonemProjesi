using Domain.Common;

namespace Domain.Entities.Persons {
    public class Patient : Person {
        Diet Diet { get; set; }
        Dietician Dietician { get; set; }
    }
}