using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePraticoDATUM.Core.Entities
{
    public class User(string fullName, string email, string password, string role) : BaseEntity
    {
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public string Password { get; private set; } = password;
        public string Role { get; private set; } = role;
        public List<Post> Posts { get; private set; } = new List<Post>();
    }
}
