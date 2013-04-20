using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElcutCRM.Data.Models;
using System.Data.Entity;

namespace ElcutCRM.Data
{
    public class UserManager
    {
        protected ElcutContext DataContext { get; set; }

        public UserManager(ElcutContext context = null)
        {
            if (context == null)
            {
                context = new ElcutContext();
            }

            this.DataContext = context;
        }

        public User Create(string email, string password)
        {
            var user = new User
            {
                Email = email,
                Password = PasswordHash.Encrypt.MD5(password)
            };

            return user;
        }

        public User Get(string email)
        {
            return DataContext.Users.SingleOrDefault(x => x.Email == email);
        }

        public bool Verify(string email, string password)
        {
            var user = this.Get(email);

            if (user == null)
                return false;

            return PasswordHash.Encrypt.MD5(password) == user.Password;
        }

        public void Save(User user)
        {
            if (user.ID == 0)
            {
                DataContext.Users.Add(user);
            }

            DataContext.SaveChanges();
        }
    }
}
