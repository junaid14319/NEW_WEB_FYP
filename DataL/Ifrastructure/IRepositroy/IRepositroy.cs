using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NEW_WEB_FYP.Ifrastructure.IRepositroy
{
    public interface IRepositroy<T> where T : class
    {
    Task <IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate=null, string? includeProperties = null);
        T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null);
       Task  Add(T entity);
        Task Delete(T entity);
        Task DeleteRenge(IEnumerable<T> entity);
    }
}
