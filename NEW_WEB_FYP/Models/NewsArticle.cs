using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEW_WEB_FYP.Model
{
    public class NewsArticle
    {
        [Key]
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        // public Category Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public  Category Category { get; set; }


    }
}
