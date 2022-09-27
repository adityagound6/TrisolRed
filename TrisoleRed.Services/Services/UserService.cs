using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrisoleRed.Data.Models;
using TrisoleRed.Services.Interfaces;
using TrisoleRed.Services.Modes;

namespace TrisoleRed.Services.Services
{
    public class UserService : IUserInterface
    {
        private readonly PropertiesContext _context;
        public UserService(PropertiesContext context)
        {
            _context = context;
        }
        public bool LogIn(LogIn model)
        {
            if(_context.Users.Any(x=>x.Email == model.Email && x.Password == model.Password))
            {
                return true;
            }
            return false;
        }

        public bool SignIn(Sign model)
        {
            if(!_context.Users.Any(x=>x.Email == model.Email))
            {
                User user = new User()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Username = model.Username,
                    Password = model.Password,
                    status = true,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
