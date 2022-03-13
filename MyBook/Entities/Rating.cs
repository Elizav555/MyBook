namespace MyBook.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public double Points { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
