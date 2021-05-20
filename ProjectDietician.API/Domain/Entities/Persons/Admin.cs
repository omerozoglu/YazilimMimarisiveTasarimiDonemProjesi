using Domain.Common;
using Domain.Common.Interfaces;

namespace Domain.Entities.Persons {
    public class Admin : Person, ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}