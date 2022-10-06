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
    public class ContactUsServices : IContactUs
    {
        private readonly PropertiesContext _context;
        public ContactUsServices(PropertiesContext context)
        {
            _context = context;
        }
        public bool IsAdd(ContactUsVm model)
        {
            ContactUs contactUs = new ContactUs()
            {
                Email = model.Email,
                Message = model.Message,
                Name = model.Name,
                Subject = model.Subject
            };
            _context.ContactUs.Add(contactUs);
            _context.SaveChanges();
            return true;
        }
    }
}
