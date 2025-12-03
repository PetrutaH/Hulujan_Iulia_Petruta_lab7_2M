namespace Hulujan_Iulia_Petruta_Lab2M.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string LastName { get; set; }

        public Genre? Genre { get; set; }
    }
}
