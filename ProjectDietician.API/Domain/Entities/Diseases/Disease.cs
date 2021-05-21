using Domain.Common;

namespace Domain.Entities.Diseases {
    public class Disease : EntityBase {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

    }
}