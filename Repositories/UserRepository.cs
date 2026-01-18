using Student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Repositories
{
    public class UserRepository
    {
        private static readonly List<User> Users = new List<User>
        {
            new User { Username = "admin", Password = "admin123" },
            new User { Username = "teacher", Password = "teach123" }
        };
        public User GetUser(string username, string password)
        {
            return Users.Find(u => u.Username == username && u.Password == password);
        }
    }
}