using System;

namespace GuavaBlog.Web
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Tags { get; set; }

        public string Excerpt { get; set; }

        public string Content { get; set; }

        public bool Featured { get; set; }

    }
}
