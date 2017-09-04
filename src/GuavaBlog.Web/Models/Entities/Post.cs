using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuavaBlog.Web.Models
{

    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsPublic { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
