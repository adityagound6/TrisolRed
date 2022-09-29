using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrisoleRed.Data.Models
{
    public class PropertiesContext : DbContext
    {
        public PropertiesContext()
        {

        }

        public PropertiesContext(DbContextOptions<PropertiesContext> options) : base(options)
        {

        }
        public virtual DbSet<PropertiesDetails> PropertiesDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=SYS69\\SQLEXPRESS;Initial Catalog=Demo5;Integrated Security=True;");
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9KTKVC2\\MSSQLSERVER01;Initial Catalog=TrisoleRed;Integrated Security=True;");
#pragma warning restore CS1030 // #warning directive
            }
        }
    }
}
