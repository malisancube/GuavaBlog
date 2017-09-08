using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GuavaBlog.Web.Models;
using GuavaBlog.Web.Services;

namespace GuavaBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            var posts = postService.GetExcerpts();
            return View(posts);
        }

        
        public IActionResult Read(string slug)
        {
            var posts = postService.GetPostBySlug(slug);
            return View(posts);
        }

        public IActionResult Tag(string tag)
        {
            var posts = postService.GetPostsByTag(tag);
            return View(posts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
