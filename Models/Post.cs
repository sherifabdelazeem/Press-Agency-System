using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required]
        [Display(Name ="Article Title")]
        public string ArticleTitle { get; set; }
        [Required]
        [Display(Name = "Article Body")]
        public string ArticleBody { get; set; }
        [Required]
        [Display(Name = "Article Image")]
        public string ArticleImage { get; set; }
        [Required]
        [Display(Name = "Number Of Viewers")]
        public int NumberOfViewers { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Likes")]
        public int Like { get; set; }
        [Display(Name = "DisLikes")]
        public int DisLike { get; set; }
       // public bool Statue { get; set; }
        [ForeignKey("PostType")]
        [Display(Name = "Article Type")]
        public int CategoryId { get;set; }
        public string UserId { get; set; }
        

        
        public virtual PostType PostType { get; set; }
        public virtual ApplicationUser User { get; set; }




    }

}