using Domain.Common.Interfaces;

namespace Domain.Common {
    public abstract class Login : ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}