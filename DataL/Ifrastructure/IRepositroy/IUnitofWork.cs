using NEW_WEB_FYP.Ifrastructure.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_WEB_FYP.Ifrastructure.IRepositroy
{
    public interface IUnitofWork
    {
        ICategoryRepo Category { get; }
        INewsAritcleRepo NewsAritcle { get; }
        IApplicationUserRepo ApplicationUser { get; }
      
        void Save();
    }
}
