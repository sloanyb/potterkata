using NUnit.Framework;

namespace PotterBookshopNetFramework
{
    [TestFixture]
    public class PotterTests
    {
        [Test]
        public void WhenOneBook_Then8Euros()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(8, basketTotal);
        }

        [Test]
        public void WhenTwoBooks_Then15_20()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(15.20m, basketTotal);
        }

        [Test]
        public void WhenThreeBooks_Then_21_60()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));
            basket.AddBook(new Book(3, "Book 3"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(21.60m, basketTotal);
        }

        [Test]
        public void WhenFourBooks_Then_25_60()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));
            basket.AddBook(new Book(3, "Book 3"));
            basket.AddBook(new Book(4, "Book 4"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(25.60m, basketTotal);
        }

        [Test]
        public void WhenFiveBooks_Then_30_Euros()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));
            basket.AddBook(new Book(3, "Book 3"));
            basket.AddBook(new Book(4, "Book 4"));
            basket.AddBook(new Book(5, "Book 5"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(30m, basketTotal);
        }

        [Test]
        public void WhenFourBooks_ThreeDifferent_RightAmount()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));
            basket.AddBook(new Book(3, "Book 3"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(29.60m, basketTotal);
        }

        [Test]
        public void WhenExampleBasketProvided_ThenCorrectAmountIsObtained()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());

            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(1, "Book 1"));
            basket.AddBook(new Book(2, "Book 2"));
            basket.AddBook(new Book(2, "Book 2"));
            basket.AddBook(new Book(3, "Book 3"));
            basket.AddBook(new Book(3, "Book 3"));
            basket.AddBook(new Book(4, "Book 4"));
            basket.AddBook(new Book(5, "Book 5"));

            var basketTotal = basket.Subtotal();
            Assert.AreEqual(51.20m, basketTotal);
        }
    }
}