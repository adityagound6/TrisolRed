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
    public class PropertiesServieses : IProperties
    {
        private readonly PropertiesContext _context;
        public PropertiesServieses(PropertiesContext context)
        {
            this._context = context;    
        }
        public List<PropertiesDetailsModelView> GetAllProperties()
        {
            throw new NotImplementedException();
        }
    }
}
