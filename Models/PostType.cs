using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace NewsWebApp.Models
{
    public class PostType
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Article Type")]
        public string ArticleType { get; set; }
        public virtual ICollection <Post> Posts { get; set; }
    }
}