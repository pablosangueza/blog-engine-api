using System.Collections.Generic;
using BlogEngine.Domain;

namespace BlogEngine.Repository
{
    public class HardCodeData
    {
        public static List<User> Users = new List<User>();

        public static void LoadData()
        {
            Users.Add(new User() {
                Name = "Pablo Sangueza",
                Username = "psangueza",
                Password = "Password1",
                Role = UserRole.Writer
            });
             Users.Add(new User() {
                Name = "Luis Sangueza",
                Username = "lsangueza",
                Password = "Password2",
                Role = UserRole.Editor
            });
             Users.Add(new User() {
                Name = "John Calvin",
                Username = "jcalvin",
                Password = "Password3",
                Role = UserRole.Public
            });

        }
    }
}