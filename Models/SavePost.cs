using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsWebApp.Models
{
    public class SavePost
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public string UserId { get; set; }

        public virtual Post post { get; set; }

        public virtual ApplicationUser user { get; set; }

    }
}