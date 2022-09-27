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
                Type = x.Type
            }).ToList();
            return model;
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
