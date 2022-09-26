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
            //PropertiesDetailsModelView model;
            List<PropertiesDetailsModelView> model = _context.PropertiesDetails.Select(x=>new PropertiesDetailsModelView()
            {
                Name = x.Name,
                area = x.area,
                Configurations = x.Configurations,
                Address = x.Address,
                image = x.image,
                StartingPrice = x.StartingPrice,
                ReraNumber = x.ReraNumber,
                Type = x.Type
            }).ToList();
            return model;
        }
    }
}
