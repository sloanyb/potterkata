using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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

    [TestFixture]
    public class PotterTests
    {
        [Test]
        public void WhenOneBook_Then8Euros()
        {
            var basket = new Basket();
            basket.AddBook(new Book(1, "Book 1"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(5, basketTotal);
        }

        [Test]
        public void WhenTwoBooks_Then9Euros50Cents()
        {
            var basket = new Basket();
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(9.50, basketTotal);
        }
    }

    public class Basket
    {
        public List<Book> BooksInBasket { get; set; }

        public Basket()
        {
            BooksInBasket = new List<Book>();
        }

        public void AddBook(Book book)
        {
            BooksInBasket.Add(book);
        }

        public decimal Subtotal()
        {
            var priceOfBook = 5m;

            var uniqueBooksCount = BooksInBasket.Select(x => x.BookId).Distinct().Count();

            var subtotal = priceOfBook * uniqueBooksCount;

            if (uniqueBooksCount == 2)
                return subtotal * 0.95m;

            return subtotal;
        }
    }
}
