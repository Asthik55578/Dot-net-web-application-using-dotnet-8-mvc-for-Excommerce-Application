using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVCCourse2.Models
{
    public static class UserRepository
    {
        private static List<User> _users = File.ReadAllLines("D:\\MVCCourse2\\MVCCourse2\\Data\\users.csv")
            .Skip(1)
            .Select(line => line.Split(','))
            .Select(parts => new User
            {
                Username = parts[1], // Username is the second column
                Password = parts[2]  // Password is the third column
            })
            .ToList();

        public static User? ValidateUser(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
