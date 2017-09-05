using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuavaBlog.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public interface IBlogService
    {
        BlogViewModel GetMetadata();
    }

    public class BlogService : IBlogService
    {
        public BlogViewModel GetMetadata()
        {
            return new BlogViewModel
            {
                Title = "Malisa Ncube",
                Description = "Speaker, Blogger and Developer",
                Logo = "/content/images/Malisa-Ncube.png",
                Bio = "I develop software for the cloud/web, mobile and enterprise. A failed stand-up comedian who loves music.",
                Url = "www.malisancube.com",
                FacebookLink = "http://facebook.com/malisancube",
                Theme = "Original",
                TwitterHandle = "malisancube",
                PostsPerPage = 10,
                MenuOptions = new List<MenuOption>
                {
                    new MenuOption {Description = "Blog", Url = "/"},
                    new MenuOption {Description = "Portfolio", Url = "/portfolio"},
                    new MenuOption {Description = "Events", Url = "/events"},
                }
            };
        }
    }
}
