using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Genre")]
        public int Genre { get; set; }

        public string Name { get; set; }

        public int height { get; set; }

        public int width { get; set; }

        public bool isset { get; set; } = false;

        public int setid { get; set; } = 0;
    }
}
