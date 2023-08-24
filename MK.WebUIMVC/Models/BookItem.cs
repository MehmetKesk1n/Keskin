namespace MK.WebUIMVC.Models
{
    public class BookItem
    {
        public int bookID { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? writer  { get; set; }
        public int? numberPage { get; set; }
        public int categoryID { get; set; }
        public string? categoryName { get; set; }

    }
}
