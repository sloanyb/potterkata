namespace PotterBookshopNetFramework
{
    public class Book
    {
        public int Isbn { get; set; }
        public string Title { get; set; }

        public decimal Price { get; set; }

        public Book(int isbn, string title, decimal price)
        {
            Isbn = isbn;
            Title = title;
            Price = price;
        }
    }
}