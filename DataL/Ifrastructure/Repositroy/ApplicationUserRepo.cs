using NEW_WEB_FYP.Ifrastructure.IRepositroy;
using NEW_WEB_FYP.DataL;
using NEW_WEB_FYP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
