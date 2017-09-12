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

        public async Task<IActionResult> Index(int pageSize = 10, int page = 1, string filter = null)
        {
            var posts = await postService.GetPostsAsync(pageSize, page, filter);
            return View(posts);
        }
        
        public async Task<IActionResult> Read(string slug)
        {
            var posts = await postService.GetPostBySlugAsync(slug);
            return View(posts);
        }

        public async Task<IActionResult> Tag(string tag)
        {
            var posts = await postService.GetPostsByTagAsync(tag);
            return View(posts);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
