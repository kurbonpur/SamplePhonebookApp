#nullable disable
using Microsoft.AspNetCore.Identity;
namespace SamplePhonebookApp.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
