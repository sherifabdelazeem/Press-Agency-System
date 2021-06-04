using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsWebApp.Models;

namespace NewsWebApp.Models
{
    public class AskForPost
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Reply { get; set; }


        public int PostId { get; set; }
        public string UserId { get; set; }

        public virtual Post post { get; set; }

        public virtual ApplicationUser user { get; set; }


    }
}