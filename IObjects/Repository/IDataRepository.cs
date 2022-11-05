using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IObjects.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Getbyid(int id);

        void Add(TEntity entity);

        void Update(TEntity entity,TEntity entity1);

        void Delete(TEntity entity);
    }
}
