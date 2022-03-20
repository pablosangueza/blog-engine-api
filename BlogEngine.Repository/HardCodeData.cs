using System;
using System.Collections.Generic;
using System.Linq;
using BlogEngine.Domain;

namespace BlogEngine.Repository
{
    public class HardCodeData
    {
        public static List<User> Users = new List<User>();
        public static List<BlogPost> Posts = new List<BlogPost>();


        public static void LoadData()
        {
            LoadUsers();
            LoadPosts();

        }

        private static void LoadPosts()
        {
            Posts.Add(new BlogPost(){
                Author = Users.Where(u => u.Username == "psangueza").SingleOrDefault(),
                Title = "Design Patterns",
                PublishDate = DateTime.Now,
                Status = PostStatus.Approved,
                Text = "Design patterns are .......",
                Comments = new List<string>()
            });
             Posts.Add(new BlogPost(){
                Author = Users.Where(u => u.Username == "psangueza").SingleOrDefault(),
                Title = "Web Technologies",
                PublishDate = DateTime.Now,
                Status = PostStatus.Approved,
                Text = "Web Technologies are .......",
                Comments = new List<string>()

            });
             Posts.Add(new BlogPost(){
                Author = Users.Where(u => u.Username == "psangueza").SingleOrDefault(),
                Title = "Machine Learning",
                PublishDate = DateTime.Now,
                Status = PostStatus.Pending,
                Text = "Machine Learning is .......",
                Comments = new List<string>()

            });
              Posts.Add(new BlogPost(){
                Author = Users.Where(u => u.Username == "psangueza").SingleOrDefault(),
                Title = "Martial Arts",
                PublishDate = DateTime.Now,
                Status = PostStatus.Editing,
                Text = "Martials arts are ........",
                Comments = new List<string>()

            });
            Posts.Add(new BlogPost(){
                Author = Users.Where(u => u.Username == "jmacarthur").SingleOrDefault(),
                Title = "Revelation",
                PublishDate = DateTime.Now,
                Status = PostStatus.Approved,
                Text = "Revelation of God .......",
                Comments = new List<string>()

            });
            Posts.Add(new BlogPost(){
                Author = Users.Where(u => u.Username == "jmacarthur").SingleOrDefault(),
                Title = "The Truth War",
                PublishDate = DateTime.Now,
                Status = PostStatus.Pending,
                Text = "THe war of truth is .......",
                Comments = new List<string>()

            });
        }

        private static void LoadUsers()
        {
            Users.Add(new User()
            {
                Name = "Pablo Sangueza",
                Username = "psangueza",
                Password = "Password1",
                Role = UserRole.Writer
            });
             Users.Add(new User()
            {
                Name = "John MacArthur",
                Username = "jmacarthur",
                Password = "Password3",
                Role = UserRole.Writer
            });
            Users.Add(new User()
            {
                Name = "Luis Sangueza",
                Username = "lsangueza",
                Password = "Password2",
                Role = UserRole.Editor
            });
            Users.Add(new User()
            {
                Name = "John Calvin",
                Username = "jcalvin",
                Password = "Password3",
                Role = UserRole.Public
            });
        }
    }
}