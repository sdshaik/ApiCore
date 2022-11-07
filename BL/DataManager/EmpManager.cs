using DAL.Model;
using IObjects.Repository;

namespace BL.DataManager
{
    public class EmpManager : IDataRepository<Tbl_Emp>
    {
        readonly EmpContext _context;
        public EmpManager(EmpContext context)
        {
            _context = context;
        }


        public IEnumerable<Tbl_Emp> GetAll()
        {
          //  return _context.Employee.ToList();
          return (IEnumerable<Tbl_Emp>) _context.Tbl_Emp.ToList();

        }
        public Tbl_Emp Getbyid(int id)
        {
            return _context.Tbl_Emp.FirstOrDefault(x => x.Empid == id);
        }
        public void Add(Tbl_Emp entity)
        {
            _context.Tbl_Emp.Add(entity);
            _context.SaveChanges();
        }
       public void Update(Tbl_Emp entity,Tbl_Emp entity1)
        {
            entity.EmpName= entity1.EmpName;
            entity.EmpGender= entity1.EmpGender;
            entity.Password=entity1.Password;
            entity.EmpSal=entity1.EmpSal;
            entity.EmpDob=entity1.EmpDob;
            entity.EmpDoj=entity1.EmpDoj;
            entity.EmpEmail=entity1.EmpEmail;
            entity.DepId=entity1.DepId;
            _context.SaveChanges();
        }

       public void Delete(Tbl_Emp entity)
        {
          _context.Tbl_Emp.Remove(entity);
            _context.SaveChanges();
        }
      
    }
}
