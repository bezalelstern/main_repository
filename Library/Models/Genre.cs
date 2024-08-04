using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Genre
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "לא ניתן להשאיר את השדה ריק")]
        public string Name { get; set; } = string.Empty;

        public List<Shelf>? Shelves { get; set; } = new List<Shelf>();

        public List<Book>? Books { get; set; } = new List<Book>();
    }
        
    
}
