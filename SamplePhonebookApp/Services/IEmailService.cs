using System.Threading.Tasks;

namespace SamplePhonebookApp.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}