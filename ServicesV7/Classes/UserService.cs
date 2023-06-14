
using ServicesV7.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesV7.Classes
{
    internal class UserService
    {
        private FilmlerContext _filmlerContext;

        public UserService()
        {
            _filmlerContext = new FilmlerContext();
        }

        public User GetUser(string name, string password)
        {
            return _filmlerContext.Users.FirstOrDefault(m => m.Name == name && m.Password == password);
        }
    }
}

