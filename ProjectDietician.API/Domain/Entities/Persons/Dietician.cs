using System.Collections.Generic;
using Domain.Common;
using Domain.Common.Interfaces;

namespace Domain.Entities.Persons {
    public class Dietician : Person, ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> PatientIds { get; set; }
    }
}