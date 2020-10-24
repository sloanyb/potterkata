namespace PotterBookshopNetFramework
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public Book(int bookId, string title)
        {
            BookId = bookId;
            Title = title;
        }
    }
}