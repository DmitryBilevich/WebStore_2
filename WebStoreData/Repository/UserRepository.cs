using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WebStoreData.Models;
using System.Configuration;

namespace WebStoreData.Repository
{
    public class UserRepository
    {
        private BaseContext context;

        public UserRepository()
        {
            context = new BaseContext(ConfigurationManager.ConnectionStrings["WebStore"].ConnectionString);
        }

        public IEnumerable<User> GetUserss()
        {
            return context.User;
        }

        public User GetUserById(int userId)
        {
            return context.User.FirstOrDefault(user => user.UserId == userId);
        }

        public User GetUserByEmail(string email)
        {
            var result=context.User.FirstOrDefault(u => u.Email == email);
            return result;
        }
        public void Create(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }

        public void Delete(int userId)
        {
            User user = context.User.FirstOrDefault(i => i.UserId == userId);
            if (user != null)
            {
                context.User.Remove(user);
                context.SaveChanges();
            }
        }

        public void Edit(User user)
        {
            User editUser = context.User.Find(user.UserId);
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.UserId = user.UserId;
            editUser.Password = user.Password;
            editUser.Email = user.Email;
            context.SaveChanges();
        }
    }
}

