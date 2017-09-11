using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace MVCSampleGrid.Data.GenericRepository
{
    public interface IGenericRepository <T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] properties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] properties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] properties);
        bool Save(params T[] items);
        bool Update(params T[] items);
        bool Delete(params T[] items);
        
    }
}
