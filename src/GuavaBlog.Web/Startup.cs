using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GuavaBlog.Web.Data;
using GuavaBlog.Web.Models;
using GuavaBlog.Web.Services;
using Microsoft.Extensions.Options;

namespace GuavaBlog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Production:SqliteConnectionString"];

            // Stripe settings
            services.Configure<BlogSettings>(Configuration.GetSection("Blog"));

            services.AddDbContext<GuavaDbContext>(options =>
                options.UseSqlite(connection)
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GuavaDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IPostService, PostService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<BlogSettings> blogOptions)
        {
            var systemFolders = new string[]
            {
                blogOptions.Value.ImagesFolder,
                blogOptions.Value.AppsFolder,
                blogOptions.Value.AttachmentsFolder
            };

            foreach (var folder in systemFolders)
            {
                Directory.CreateDirectory($@"{env.WebRootPath}\{folder}");
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute("blog_route", "post/{*slug}",
                    defaults: new { controller = "Home", action = "Read" });

                routes.MapRoute("tag_route", "tag/{*slug}",
                    defaults: new { controller = "Home", action = "Tag" });
            });
        }
    }
}
