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
        public double Area { get; set; }
        public string PropertiesName { get; set; }
        public string Configurations { get; set; }
        public double StartingPrice { get; set; }
        public string ReraNumber { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public string Images { get; set; }
        public string City { get; set; }
    }
}
