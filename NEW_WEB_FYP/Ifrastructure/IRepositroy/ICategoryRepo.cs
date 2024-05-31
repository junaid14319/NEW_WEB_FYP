using Firstpro.Models;
using NEW_WEB_FYP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_WEB_FYP.Ifrastructure.IRepositroy
{
    public interface ICategoryRepo : IRepositroy<Category>
    {
        //bool Any(Func<object, bool> value);
        //Task FirstOrDefaultAsync(Func<object, bool> value);
        void Update(Category catgr);
    }
}
