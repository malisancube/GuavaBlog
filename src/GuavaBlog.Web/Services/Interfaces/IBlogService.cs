using System.Threading.Tasks;

namespace GuavaBlog.Web.Services
{
    public interface IBlogService
    {
        Task<BlogViewModel> GetMetadata();
        Task<int> SaveMetaData(BlogViewModel model);
    }
}
