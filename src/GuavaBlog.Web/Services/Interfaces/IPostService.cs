using System.Collections.Generic;

namespace GuavaBlog.Web.Services
{
    public interface IPostService
    {
        List<PostViewModel> GetPosts(int pageSize = 10, int page = 1, string filter = null);
        List<PostViewModel> GetExcerpts(int pageSize = 10, int page = 1, string filter = null);
        string GetExcerpt(int postId);
        string GetStory(int postId);
        void SavePost(PostViewModel post);
    }
}
