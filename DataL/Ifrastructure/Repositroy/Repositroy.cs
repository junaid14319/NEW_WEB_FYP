using NEW_WEB_FYP.Ifrastructure.IRepositroy;
using Microsoft.EntityFrameworkCore;
using NEW_WEB_FYP.DataL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NEW_WEB_FYP.Ifrastructure.Repositroy
{
    public class Repositroy<T> : IRepositroy<T> where T : class
    {

        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;
        public Repositroy(AppDbContext context)
        {
            _context = context;
           // _context.Product.Include(x = x.Catgr);
            _dbSet = _context.Set<T>(); 
        
        }

        public async Task Add(T entity)
        {
           _dbSet.Add(entity);    
        }
        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity); 
        }

        public async Task DeleteRenge(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public async Task<IEnumerable<T>> GetAll( Expression<Func<T, bool>>? predicate=null, string? includeProperties = null)
        {
            //To display the Category name in Product Index page ot table 
            IQueryable<T> query = _dbSet;
            if(predicate != null) 
            {
             query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
           
        }

        public T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            //To display the Category name in Product Index page ot table 
            IQueryable<T>query = _dbSet;
            query = query.Where(predicate);
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        
        }
    }
}
