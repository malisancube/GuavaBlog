using System;
using System.ComponentModel.DataAnnotations;
using GuavaBlog.Web.Models;
using Markdig;

namespace GuavaBlog.Web
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Slug => this.GetSlug();

        public DateTime PublishedDate { get; set; }

        public string Tags { get; set; }

        [Required]
        public string Content { get; set; }

        public string Html { get; set; }

        public bool Featured { get; set; }

        public DateTime EditedDate { get; set; }

        public bool IsPublic { get; internal set; }

        public string Excerpt => this.GetExcerpt(400);

        public static implicit operator Post(PostViewModel post)
        {
            return new Post
            {
                Id = post.Id,
                Title = post.Title,
                Slug = post.GetSlug(),
                Content = post.Content,
                IsPublic = post.IsPublic,
                PublishDate = post.PublishedDate,
                Featured = post.Featured
            };
        }

        public static implicit operator PostViewModel(Post post)
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            return new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                IsPublic = post.IsPublic,
                PublishedDate = post.PublishDate,
                Featured = post.Featured,
                Html = Markdown.ToHtml(post.Content, pipeline)
            };
        }
    }
}
