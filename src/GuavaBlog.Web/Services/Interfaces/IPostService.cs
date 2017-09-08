using System.Collections.Generic;
using System.Threading.Tasks;
using GuavaBlog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuavaBlog.Web.Services
{
    public interface IPostService
    {
        Task<PaginatedList<Post>> GetPostsAsync(int pageSize = 10, int page = 1, string filter = null);
        Task<int> SavePostAsync(PostViewModel post, bool delete = false);
        Task<PostViewModel> GetPostBySlugAsync(string slug);
        Task<List<PostViewModel>> GetPostsByTagAsync(string tag, int pageSize = 10, int page = 1);
        PostViewModel GetPostById(int id);
    }
}
