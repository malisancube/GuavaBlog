using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuavaBlog.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuavaBlog.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPostService postService;

        public AdminController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> Index(int pageSize = 10, int page = 1, string filter = null)
        {
            var posts = await postService.GetPostsAsync(pageSize, page, filter);
            return View(posts);
        }

        public IActionResult NewPost()
        {
            var post = new PostViewModel
            {
                PublishedDate = DateTime.Now,
                IsPublic = true
            };
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> NewPost(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                await postService.SavePostAsync(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public IActionResult EditPost(int id)
        {
            var post = this.postService.GetPostById(id);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                await postService.SavePostAsync(post);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Settings()
        {
            var blog = new BlogViewModel();
            return View(blog);
        }

        [HttpPost]
        public IActionResult Settings(BlogViewModel blog)
        {
            return View();
        }

        public IActionResult Experimental()
        {
            var blog = new BlogViewModel();
            return View(blog);
        }


    }
}