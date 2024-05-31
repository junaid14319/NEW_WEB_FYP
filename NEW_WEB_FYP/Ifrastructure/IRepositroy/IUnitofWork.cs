namespace NEW_WEB_FYP.Ifrastructure.IRepositroy
{
    public interface IUnitofWork
    {
        ICategoryRepo Category { get; }
        INewsAritcleRepo NewsArticle { get; }
        IApplicationUserRepo ApplicationUser { get; }
      
        void Save();
    }
}
