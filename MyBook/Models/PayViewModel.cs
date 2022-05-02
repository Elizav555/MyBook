using MyBook.Entities;

namespace MyBook.Models
{
    public class PayViewModel
    {
        public bool isGift { get; set; } = false;
        public string UserId { get; set; }
        public int Period { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public string? SpecsName { get; set; }
        public int? SpecsId { get; set; }
    }
}
