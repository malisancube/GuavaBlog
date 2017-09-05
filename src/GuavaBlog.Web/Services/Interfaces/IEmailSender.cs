using System;
using System.Linq;
using System.Threading.Tasks;

namespace GuavaBlog.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
