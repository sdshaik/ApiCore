using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Tbl_Dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }

        public string DeptName { get; set; }

        public string DeptHod { get; set; }
    }
}
