namespace MyBook.Entities
{
    public class Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }


        public virtual ICollection<SubscrType> SubscrTypes { get; set; }
    }
}
