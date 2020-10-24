using System;
using System.Collections.Generic;
using System.Linq;

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
            decimal bestPossibleDiscount = 0m;

            for (int i = 1; i <= books.Count; i++)
            {
                int evaluationSetSize = i;

                var discountforSetSize = DiscountForSetSize(books, evaluationSetSize);

                if (discountforSetSize > bestPossibleDiscount)
                    bestPossibleDiscount = discountforSetSize;
            }

            return bestPossibleDiscount;
        }

        private decimal DiscountForSetSize(List<Book> books, int evaluationSetSize)
        {
            var discountAmount = 0m;

            var splitterOptions = new SetSplitterOptions
            {
                MaximumSetSize = evaluationSetSize
            };

            var splitter = new SetSplitter(splitterOptions);
            var setsOfBooks = splitter.Split(books);

            foreach (var setOfBooks in setsOfBooks)
            {
                var quantityOfBooks = setOfBooks.Books.Count;
                var basePriceOfSet = setOfBooks.Books.Sum(x => x.Price);

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