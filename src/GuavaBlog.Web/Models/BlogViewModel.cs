using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GuavaBlog.Web
{
    public class BlogViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string Url { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }

        [Display(Name = "Logo")]
        public string LogoFileName { get; set; }

        [Display(Name = "Logo")]
        public IFormFile Logo { get; set; }

        [Display(Name = "Cover")]
        public string CoverFileName { get; set; }

        [Display(Name = "Cover")]
        public IFormFile Cover { get; set; }

        [Display(Name = "Numbr eof posts per page")]
        public int PostsPerPage { get; set; }

        public string Permalinks { get; set; }

        [Display(Name = "Twitter Handle")]
        public string TwitterHandle { get; set; }

        [Display(Name = "FaceBook Page")]
        public string FacebookLink { get; set; }

        [Display(Name = "LinkedIN Page")]
        public string LinkedInLink { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public string Theme { get; set; }

        public List<MenuOption> MenuOptions { get; set; }

        public static implicit operator Blog(BlogViewModel blog)
        {
            return new Blog
            {
                Id = blog.Id,
                Title = blog.Title,
                Cover = blog.CoverFileName,
                Logo = blog.LogoFileName,
                Description = blog.Description,
                FacebookLink = blog.FacebookLink,
                LinkedInLink = blog.LinkedInLink,
                EmailAddress = blog.EmailAddress,
                Link = blog.Link,
                Permalinks = blog.Permalinks,
                PostsPerPage = blog.PostsPerPage,
                Theme = blog.Theme
            };
        }

        public static implicit operator BlogViewModel(Blog blog)
        {
            return new BlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                CoverFileName = blog.Cover,
                LogoFileName = blog.Logo,
                FacebookLink = blog.FacebookLink,
                LinkedInLink = blog.LinkedInLink,
                EmailAddress = blog.EmailAddress,
                Link = blog.Link,
                Permalinks = blog.Permalinks,
                PostsPerPage = blog.PostsPerPage,
                Theme = blog.Theme
            };
        }
    }
}
