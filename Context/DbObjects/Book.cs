using System.ComponentModel.DataAnnotations;

namespace Context.DbObjects
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Author { get; set; }
    }
}
