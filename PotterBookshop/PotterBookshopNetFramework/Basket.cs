﻿using System.Collections.Generic;
using System.Linq;

namespace PotterBookshopNetFramework
{
    public class Basket
    {
        private readonly IDiscountCalculator _discountCalculator;

        public List<Book> BooksInBasket { get; set; }

        public Basket(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
            BooksInBasket = new List<Book>();
        }

        public void AddBook(Book book) =>
            BooksInBasket.Add(book);

        public decimal BasketTotal()
        {
            var subtotal = BooksInBasket.Sum(x => x.Price);

            var discountAmount = _discountCalculator.CalculateDiscountAmount(BooksInBasket);

            return subtotal - discountAmount;
        }
    }
}
