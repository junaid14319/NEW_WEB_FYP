using Firstpro.Models;
using NEW_WEB_FYP.Model;
using NEW_WEB_FYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_WEB_FYP.Ifrastructure.IRepositroy
{
    public interface INewsAritcleRepo : IRepositroy<NewsArticle>
    {
    //    bool Any(Func<object, bool> value);
      //  Task FirstOrDefaultAsync(Func<object, bool> value);
        void Update(NewsArticle newsArticle);
       // void Update(Catgr catgr);
    }
}
