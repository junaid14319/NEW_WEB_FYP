using Firstpro.Models;
using NEW_WEB_FYP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Firstpro.Models.ViewModels
{
 
    public class CatgrVm
    {
        public Category Catgr { get; set; }

        public IEnumerable<Category> catgrs { get; set; } = new List<Category>();
    }
}
