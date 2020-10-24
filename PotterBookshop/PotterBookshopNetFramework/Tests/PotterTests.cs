using NUnit.Framework;

namespace PotterBookshopNetFramework.Tests
{
    [TestFixture]
    public class PotterTests
    {
        private decimal priceOfOneBook = 8m;

        [Test]
        public void WhenOneBook_Then8Euros()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));

            var basketTotal = basket.BasketTotal();
            Assert.AreEqual(8, basketTotal);
        }

        [Test]
        public void WhenTwoBooks_Then15_20()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));
            basket.AddBook(new Book(2, "Book 2", priceOfOneBook));

            var basketTotal = basket.BasketTotal();
            Assert.AreEqual(15.20m, basketTotal);
        }

        [Test]
        public void WhenThreeBooks_Then_21_60()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));
            basket.AddBook(new Book(2, "Book 2", priceOfOneBook));
            basket.AddBook(new Book(3, "Book 3", priceOfOneBook));

            var basketTotal = basket.BasketTotal();
            Assert.AreEqual(21.60m, basketTotal);
        }

        [Test]
        public void WhenFourBooks_Then_25_60()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));
            basket.AddBook(new Book(2, "Book 2", priceOfOneBook));
            basket.AddBook(new Book(3, "Book 3", priceOfOneBook));
            basket.AddBook(new Book(4, "Book 4", priceOfOneBook));

            var basketTotal = basket.BasketTotal();
            Assert.AreEqual(25.60m, basketTotal);
        }

        [Test]
        public void WhenFiveBooks_Then_30_Euros()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));
            basket.AddBook(new Book(2, "Book 2", priceOfOneBook));
            basket.AddBook(new Book(3, "Book 3", priceOfOneBook));
            basket.AddBook(new Book(4, "Book 4", priceOfOneBook));
            basket.AddBook(new Book(5, "Book 5", priceOfOneBook));

            var basketTotal = basket.BasketTotal();
            Assert.AreEqual(30m, basketTotal);
        }

        [Test]
        public void WhenFourBooks_ThreeDifferent_RightAmount()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());
            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));
            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));
            basket.AddBook(new Book(2, "Book 2", priceOfOneBook));
            basket.AddBook(new Book(3, "Book 3", priceOfOneBook));

            var basketTotal = basket.BasketTotal();
            Assert.AreEqual(29.60m, basketTotal);
        }

        [Test]
        public void WhenExampleBasketProvided_ThenCorrectAmountIsObtained()
        {
            var basket = new Basket(new SetBasedDiscountCalculator());

            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));
            basket.AddBook(new Book(1, "Book 1", priceOfOneBook));
            basket.AddBook(new Book(2, "Book 2", priceOfOneBook));
            basket.AddBook(new Book(2, "Book 2", priceOfOneBook));
            basket.AddBook(new Book(3, "Book 3", priceOfOneBook));
            basket.AddBook(new Book(3, "Book 3", priceOfOneBook));
            basket.AddBook(new Book(4, "Book 4", priceOfOneBook));
            basket.AddBook(new Book(5, "Book 5", priceOfOneBook));

            var basketTotal = basket.BasketTotal();
            Assert.AreEqual(51.20m, basketTotal);
        }
    }
}