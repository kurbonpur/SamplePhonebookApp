using System.Collections.Generic;

#nullable disable

namespace SamplePhonebookApp.Models
{
    public class Category
    {
        public Category()
        {
            Phones = new List<Phone>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
