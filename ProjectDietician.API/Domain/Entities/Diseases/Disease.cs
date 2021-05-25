using Domain.Common;

namespace Domain.Entities.Diseases {
    public class Disease : EntityBase {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}