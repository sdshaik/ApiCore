using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Tbl_Emp
    {
        [Key]
        public int Empid { get; set; }
        public string EmpName { get; set; }

        public string EmpGender { get; set; }

        public String Password { get; set; }

        public double EmpSal { get; set; }

        public DateTime EmpDob { get; set; }

        public DateTime EmpDoj { get; set; }

        public string EmpEmail { get; set; }

        public int DepId { get; set; }
        //[ForeignKey("DepId")
        //public Tbl_Dept dept { get; set; }
    }
}
