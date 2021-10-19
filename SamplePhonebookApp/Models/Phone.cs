#nullable disable

using System.ComponentModel.DataAnnotations;

namespace SamplePhonebookApp.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string Name { get; set; }

        [MaxLength(15, ErrorMessage = "Telephone cannot be longer than 15 characters.")]
        public string Telephone { get; set; }

        [MaxLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
