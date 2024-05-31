using NEW_WEB_FYP.Ifrastructure.IRepositroy;
using NEW_WEB_FYP.DataL;
using NEW_WEB_FYP.Model;

namespace NEW_WEB_FYP.Ifrastructure.Repositroy
{
    public class CategoryRepo : Repositroy<Category>, ICategoryRepo
    {
        private AppDbContext _context;
        public CategoryRepo(AppDbContext context) : base(context)
        {
            _context = context;

        }

        //public bool Any(Func<object, bool> value)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task FirstOrDefaultAsync(Func<object, bool> value)
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(Category catgr)
        {
            //  _context.Catgrs.Update(catgr);
            // _context.Products.Update(Product);


            var Catgrdb = _context.Categories.FirstOrDefault(x=>x.CategoryID == catgr.CategoryID);
            if (Catgrdb != null) 
            {
                Catgrdb.Name =  catgr.Name;
           
                Catgrdb.UpdatedDate = DateTime.Now;
            }

        }
   

     
    }
}
