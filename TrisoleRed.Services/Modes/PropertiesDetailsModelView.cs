using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrisoleRed.Services.Modes
{
    public class PropertiesDetailsModelView
    {
        public string Type { get; set; }
        public string Address { get; set; }
        public double area { get; set; }
        public string Name { get; set; }
        public string Configurations { get; set; }
        public double StartingPrice { get; set; }
        public string ReraNumber { get; set; }
        public string image { get; set; }
        public List<string> images { get; set; }
    }
}
