using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GuavaBlog.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewPost()
        {
            var post = new PostViewModel();
            return View(post);
        }

        [HttpPost]
        public IActionResult NewPost(PostViewModel post)
        {
            return View();
        }

        public IActionResult EditPost(int id)
        {
            var post = new PostViewModel();
            return View(post);
        }

        [HttpPost]
        public IActionResult EditPost(PostViewModel post)
        {
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

        public IActionResult Experiental()
        {
            return View();
        }


    }
}