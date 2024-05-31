using Firstpro.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEW_WEB_FYP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NEW_WEB_FYP.Models.ViewModels
{
    public class NewsArticleVm
    {
        
        public NewsArticle newsArticle { get; set; }
        [ValidateNever]
        public IEnumerable<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
    }

