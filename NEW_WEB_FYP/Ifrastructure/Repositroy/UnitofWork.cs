using NEW_WEB_FYP.Data;
using NEW_WEB_FYP.Ifrastructure.IRepositroy;

namespace NEW_WEB_FYP.Ifrastructure.Repositroy
{
    public class UnitofWork:IUnitofWork
    {
        private AppDbContext _context;
        public ICategoryRepo Category { get; private set; }
        public INewsAritcleRepo NewsArticle { get; private set; }
        public IApplicationUserRepo ApplicationUser { get; private set; }



        public UnitofWork(AppDbContext context, IApplicationUserRepo applicationUser = null)
        {
            _context = context;
            Category = new CategoryRepo(context);
            NewsArticle = new NewsAritcleRepo(context);
           ApplicationUser = new ApplicationUserRepo(context);

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
