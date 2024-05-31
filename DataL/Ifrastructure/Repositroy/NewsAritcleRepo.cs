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
    public class NewsAritcleRepo : Repositroy<NewsArticle>,INewsAritcleRepo
    {
        private AppDbContext _context;
        public NewsAritcleRepo(AppDbContext context) : base(context)
        {
            _context = context;

        }
        public void Update(NewsArticle newsArticle)
        {
            //  _context.NewsArticle.Update(product);
            var NewsArticledb = _context.NewsArticles.FirstOrDefault(x => x.NewsId == newsArticle.NewsId);
            if (NewsArticledb != null)
            {
                NewsArticledb.Title = newsArticle.Title;
                NewsArticledb.Author = newsArticle.Author;
                NewsArticledb.Content = newsArticle.Content;
                if (NewsArticledb.ImageUrl != null)
                    NewsArticledb.ImageUrl = newsArticle.ImageUrl;
            }

        }


        }



    }

