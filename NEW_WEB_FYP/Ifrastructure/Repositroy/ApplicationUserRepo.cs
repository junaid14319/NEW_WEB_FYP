using NEW_WEB_FYP.Data;
using NEW_WEB_FYP.Ifrastructure.IRepositroy;
using NEW_WEB_FYP.Model;

namespace NEW_WEB_FYP.Ifrastructure.Repositroy
{
    public class ApplicationUserRepo:Repositroy<ApplicationUser>,IApplicationUserRepo
    {
        private AppDbContext _Context;

        public ApplicationUserRepo(AppDbContext context):base(context) 
        {
            _Context = context;
        }
    }
}
