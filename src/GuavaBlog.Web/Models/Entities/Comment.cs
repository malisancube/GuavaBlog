using System;
using System.Collections.Generic;

namespace GuavaBlog.Web.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public ICollection<Comment> Replies { get; set; }
    }
}
