namespace MyBook.Entities
{
    public class FavGenre
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
