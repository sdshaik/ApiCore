using DAL.Model;
using IObjects.Repository;

namespace BL.DataManager
{
    public class DeptManager:IDataRepository<Tbl_Dept>
    {
        readonly EmpContext _context;
        public DeptManager(EmpContext context)
        {
            _context = context;
        }

        public IEnumerable<Tbl_Dept> GetAll()
        {
          
            return _context.Tbl_Dept.ToList();

        }
        public Tbl_Dept? Getbyid(int id)
        {
            return _context.Tbl_Dept.FirstOrDefault(x => x.DeptId == id);
        }
        public void Add(Tbl_Dept entity)
        {
            _context.Tbl_Dept.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Tbl_Dept entity, Tbl_Dept entity1)
        {
           entity.DeptName=entity1.DeptName;
           entity.DeptHod=entity1.DeptHod;
            _context.SaveChanges();
        }

        public void Delete(Tbl_Dept entity)
        {
            _context.Tbl_Dept.Remove(entity);
            _context.SaveChanges();
        }

    }
}
