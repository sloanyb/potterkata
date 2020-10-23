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
            Assert.AreEqual(8, basketTotal);
        }

        [Test]
        public void WhenTwoBooks_Then15_20()
        {
            var basket = new Basket();
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(15.20m, basketTotal);
        }

        [Test]
        public void WhenThreeBooks_Then_21_60()
        {
            var basket = new Basket();
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));
            basket.AddBook(new Book(3, "Book 3"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(21.60m, basketTotal);
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
            var priceOfBook = 8m;

            var uniqueBooksCount = BooksInBasket.Select(x => x.BookId).Distinct().Count();

            var subtotal = priceOfBook * uniqueBooksCount;

            if (uniqueBooksCount == 2)
                return subtotal * 0.95m;

            if (uniqueBooksCount == 3)
                return subtotal * 0.9m;

            return subtotal;
        }
    }
}
