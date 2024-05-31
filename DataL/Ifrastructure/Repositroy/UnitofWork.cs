using NEW_WEB_FYP.Ifrastructure.IRepositroy;
using NEW_WEB_FYP.Data;
using NEW_WEB_FYP.DataL;
using NEW_WEB_FYP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_WEB_FYP.Ifrastructure.Repositroy
{
    public class UnitofWork:IUnitofWork
    {
        private AppDbContext _context;
        public ICategoryRepo Category { get; private set; }
        public INewsAritcleRepo NewsAritcle { get; private set; }
        public IApplicationUserRepo ApplicationUser { get; private set; }



        public UnitofWork(AppDbContext context, IApplicationUserRepo applicationUser = null)
        {
            _context = context;
            Category = new CategoryRepo(context);
            NewsAritcle = new NewsAritcleRepo(context);
           ApplicationUser = new ApplicationUserRepo(context);

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
