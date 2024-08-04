using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Shelf
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Height")]
        public int Height { get; set; }

        [Display(Name = "Width")]
        public int Width { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }

        public List<Book>? Book { get; set; }
    }
}
