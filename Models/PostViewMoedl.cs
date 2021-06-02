using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsWebApp.Models
{
    public class PostViewMoedl
    {
        public string ArticleTitle { get; set; }
        public IEnumerable<AskForPost> Items { get; set; }
    }
}