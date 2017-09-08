using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuavaBlog.Web.Data;
using GuavaBlog.Web.Models;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuavaBlog.Web.Services
{
    public class PostService : IPostService
    {
        private readonly GuavaDbContext _guavaDbContext;

        public PostService(GuavaDbContext guavaDbContext)
        {
            this._guavaDbContext = guavaDbContext;
        }

        public async Task<PaginatedList<Post>> GetPostsAsync(int pageSize = 10, int page = 1, string filter = null)
        {
            var posts = _guavaDbContext
                .Posts
                .OrderByDescending(p => p.PublishDate);
            return await PaginatedList<Post>.CreateAsync(posts.AsNoTracking(), page, pageSize);
        }

        public async Task<int> SavePostAsync(PostViewModel model, bool delete = false)
        {
            var post = (Post)model;
            if (model.Id != 0)
            {
                var item = _guavaDbContext.Posts.Find(model.Id);
                if (item != null && !delete)
                {
                    _guavaDbContext.Entry(item).State = EntityState.Modified;
                }
                else if (item != null)
                {
                    _guavaDbContext.Entry(item).State = EntityState.Deleted;
                }
            }
            else
            {
                _guavaDbContext
                    .Posts
                    .Add(post);
            }
            return await _guavaDbContext.SaveChangesAsync();
        }

        public async Task<PostViewModel> GetPostBySlugAsync(string slug)
        {
            var cleaned = slug.Replace("/", string.Empty);
            var post = await _guavaDbContext
                .Posts
                .FirstOrDefaultAsync(p => p.Slug == cleaned);
            if (post == null)
                return null;
            return (PostViewModel)post;
        }

        public async Task<List<PostViewModel>> GetPostsByTagAsync(string tag, int pageSize = 10, int page = 1)
        {
            var posts = await _guavaDbContext
                .Posts
                .Where(p => p.Slug == tag)
                .Select(post =>
                    new PostViewModel
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        IsPublic = post.IsPublic,
                        PublishedDate = post.PublishDate,
                        Featured = post.Featured
                    })
                    .ToListAsync();
            return posts;
        }

        public PostViewModel GetPostById(int id)
        {
            return _guavaDbContext.Posts.Find(id);
        }
    }
}
