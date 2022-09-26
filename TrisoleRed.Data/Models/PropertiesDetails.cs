using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrisoleRed.Data.Models
{
    public class PropertiesDetails
    {
        [Key]
        public int PropertiesId { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public double area { get; set; }
        public string Name { get; set; }
        public string Configurations { get; set; }
        public double StartingPrice { get; set; }
        public string ReraNumber { get; set; }
        public string image { get; set; }
        public string images { get; set; }
    }
}
