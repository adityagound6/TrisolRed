using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TrisoleRed.Data.Models;
using TrisoleRed.Services.Interfaces;
using TrisoleRed.Services.Modes;

namespace TrisoleRed.Services.Services
{
    public class PropertiesServieses : IProperties
    {
        private readonly PropertiesContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public PropertiesServieses(PropertiesContext context, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            this._context = context;    
        }
        public List<PropertiesDetails> GetByCityName(string city)
        {
            var listd = _context.PropertiesDetails.ToList().Where(x => x.City == city).ToList();
            return listd;
        }

        public List<string> GetAllCity()
        {
            var city = _context.PropertiesDetails.Select(x => x.City).Distinct().ToList();
            return city;
        }

        public bool AddPropty(PropertiesDetailsModelView model)
        {
            try
            {
                PropertiesDetails propertiesDetails = new PropertiesDetails()
                {
                    StartingPrice = model.StartingPrice,
                    Address = model.Address,
                    Area = model.area,
                    Configurations = model.Configurations,
                    Image = ProcessUploadFile(model.image),
                    Images = ProcessUploadFile(model.image),
                    PropertiesName = model.Name,
                    ReraNumber = model.ReraNumber,
                    Type = model.Type
                };
                _context.PropertiesDetails.Add(propertiesDetails);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<PropertiesDetailsModelView> GetAllProperties()
        {
            //PropertiesDetailsModelView model;
            List<PropertiesDetailsModelView> model = _context.PropertiesDetails.Select(x=>new PropertiesDetailsModelView()
            {
                Name = x.PropertiesName,
                area = x.Area,
                Configurations = x.Configurations,
                Address = x.Address,
                imageString = x.Image,
                StartingPrice = x.StartingPrice,
                ReraNumber = x.ReraNumber,
                Type = x.Type,
                PropertiesId = x.PropertiesId
            }).ToList();
            return model;
        }

        public PropertiesDetailsModelView GetById(int id)
        {
            PropertiesDetailsModelView model;
            model = _context.PropertiesDetails.Where(x => x.PropertiesId == id).Select(x=>new PropertiesDetailsModelView()
            {
                Configurations = x.Configurations,
                Address = x.Address,
                StartingPrice = x.StartingPrice,
                area = x.Area,
                imageString=x.Image,
                ReraNumber = x.ReraNumber,
                Type = x.Type,
            }).FirstOrDefault();
            if (model != null)
            {
                return model;
            }
            else
            {
                return model;
            }
        }

        public bool Update(PropertiesDetailsModelView modelView)
        {
            try
            {
                PropertiesDetails model = _context.PropertiesDetails.Where(x => x.PropertiesId == modelView.PropertiesId).FirstOrDefault();
                if (model != null)
                {
                    _context.PropertiesDetails.Update(model);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        [Obsolete]
        private string ProcessUploadFile(IFormFile model)
        {
            string uniqueFileName = null;
            if (model != null)
            {
                string photoUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                string filePath = Path.Combine(photoUpload, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
