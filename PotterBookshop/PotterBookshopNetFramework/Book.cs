namespace PotterBookshopNetFramework
{
    public class Book
    {
        public int Isbn { get; set; }
        public string Title { get; set; }

        public Book(int isbn, string title)
        {
            Isbn = isbn;
            Title = title;
        }
    }
}