namespace Library.Models.Viewmodel
{
    public class BookWithSet
    {
        public Book Book { get; set; }
        public List<Bookset> Booksets { get; set; }
        public List<Genre> Genres { get; set; } 
        public List<Shelf> Shelf { get; set; }
        public int SelectId { get; set; }
    }
}
