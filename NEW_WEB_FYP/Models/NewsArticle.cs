using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEW_WEB_FYP.Model
{
    public class NewsArticle
    {
        [Key]
        public int NewsId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [ValidateNever]
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Author { get; set; }
        // public Category Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        [ValidateNever]
        [Required]
        public  Category Category { get; set; }


    }
}
