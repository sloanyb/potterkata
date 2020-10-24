using System;
using System.Collections.Generic;

namespace PotterBookshopNetFramework
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscountAmount(List<Book> b);
    }

    public class SetBasedDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscountAmount(List<Book> books)
        {
            var discountAmount = 0m;

            var setSplitter = new SetSplitter();
            var setsOfBooks = setSplitter.Split(books);

            foreach (var setOfBooks in setsOfBooks)
            {
                var quantityOfBooks = setOfBooks.Books.Count;
                var basePriceOfSet = quantityOfBooks * 8m;

                switch (quantityOfBooks)
                {
                    case 1:
                        discountAmount += 0;
                        break;
                    case 2:
                        discountAmount += basePriceOfSet * 0.05m;
                        break;
                    case 3:
                        discountAmount += basePriceOfSet * 0.1m;
                        break;
                    case 4:
                        discountAmount += basePriceOfSet * 0.2m;
                        break;
                    case 5:
                        discountAmount += basePriceOfSet * 0.25m;
                        break;

                    default:
                        throw new Exception($"Not sure how to handle this amount of books in the set: {quantityOfBooks}");
                }
            }

            return discountAmount;
        }
    }
}