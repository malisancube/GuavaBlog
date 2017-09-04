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
                Description = "Speaker, Blogger and Developer"
            };
        }
    }
}
