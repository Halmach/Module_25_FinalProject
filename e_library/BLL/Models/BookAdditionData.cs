namespace e_library.BLL.Models
{
    public class BookAdditionData
    {
        public string Title { get;  set; }
        public string Description { get;  set; }
        public int ReleaseYser { get;  set; }
        public int GenreId { get; set; }    
        public int AuthorId { get; set; }
    }
}