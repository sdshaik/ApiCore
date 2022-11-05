using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Model
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Tbl_Emp> Tbl_Emp { get; set; }

        public DbSet<Tbl_Dept> Tbl_Dept { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }

}
