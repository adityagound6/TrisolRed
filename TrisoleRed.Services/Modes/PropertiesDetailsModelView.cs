using Microsoft.AspNetCore.Http;

namespace TrisoleRed.Services.Modes
{
    public class PropertiesDetailsModelView
    {
        public int PropertiesId { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double area { get; set; }
        public string Name { get; set; }
        public string Configurations { get; set; }
        public double StartingPrice { get; set; }
        public string ReraNumber { get; set; }
        public IFormFile image { get; set; }
        public string? imageString { get; set; }
        public List<string> images { get; set; } = null;
        public ContactUsVm ContactUsVm { get; set; } = null;
    }
}
