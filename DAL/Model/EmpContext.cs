using Microsoft.EntityFrameworkCore;


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
