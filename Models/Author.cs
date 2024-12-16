using System.ComponentModel.DataAnnotations;

namespace Janos_Nagy_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        [Display(Name = "Author")]
        public string? AuthorName { get; set; }
        public ICollection<Book>? Books { get; set; } //navigation property
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
