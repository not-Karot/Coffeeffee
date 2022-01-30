using System;
namespace Coffeeffee.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        private string Token;

        public User()
        {
        }
        public User(string Token)
        {
            this.Token = Token;
        }
    }
}
