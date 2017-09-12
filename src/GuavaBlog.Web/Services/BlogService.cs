using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GuavaBlog.Web.Data;
using GuavaBlog.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Microsoft.WindowsAzure.Storage.Table;

namespace GuavaBlog.Web.Services
{
    public class BlogService : IBlogService
    {
        private GuavaDbContext _guavaDbContext;
        private readonly IOptions<BlogSettings> _blogOptions;
        private readonly IHostingEnvironment _env;

        public BlogService(IOptions<BlogSettings> blogOptions, IHostingEnvironment env, GuavaDbContext guavaDbContext)
        {
            this._guavaDbContext = guavaDbContext;
            _blogOptions = blogOptions;
            this._env = env;
        }

        public async Task<BlogViewModel> GetMetadata()
        {
            var item = await _guavaDbContext
                .Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync();
            var blog = (BlogViewModel)item;

            blog.MenuOptions = new List<MenuOption>
            {
                new MenuOption {Description = "Portfolio", Url = "/portfolio"},
                new MenuOption {Description = "Events", Url = "/events"},
            };
            return blog;
        }

        public async Task<int> SaveMetaData(BlogViewModel model)
        {
            var blog = (Blog)model;
            if (model.Logo?.Length > 0)
            {
                var fileName = $@"{_env.WebRootPath}\{_blogOptions.Value.ImagesFolder}\{model.Logo.FileName}";

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    await model.Logo.CopyToAsync(stream);
                }
                blog.Logo = $@"{_blogOptions.Value.ImagesFolder}\{model.Logo.FileName}"; ;
            }

            if (model.Cover?.Length > 0)
            {
                var fileName = $@"{_env.WebRootPath}\{_blogOptions.Value.ImagesFolder}\{model.Cover.FileName}";
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    await model.Cover.CopyToAsync(stream);
                }
                blog.Cover = $@"{_blogOptions.Value.ImagesFolder}\{model.Cover.FileName}";
            }

            if (model.Id != 0)
            {
                var item = await _guavaDbContext
                    .Blogs
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                if (item != null)
                {
                    _guavaDbContext.Entry(blog).State = EntityState.Modified;
                }
            }
            else
            {
                _guavaDbContext
                    .Blogs
                    .Add(blog);
            }



            return await _guavaDbContext.SaveChangesAsync();

        }
    }

}
