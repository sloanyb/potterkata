using System.Collections.Generic;
using NUnit.Framework;

namespace PotterBookshopNetFramework
{
    [TestFixture]
    public class SetSplitterTests
    {
        [Test]
        public void WhenThreeDifferentBooks_ThenOneSet()
        {
            var books = new List<Book>()
            {
                new Book(1, "Book 1"),
                new Book(2, "Book 2"),
                new Book(3, "Book 3")
            };

            var splitterOptions = new SetSplitterOptions
            {
                MaximumSetSize = 100
            };

            var splitter = new SetSplitter(splitterOptions);
            var result = splitter.Split(books);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void WhenTwoFullSets_ThenTwo()
        {
            var books = new List<Book>()
            {
                new Book(1, "Book 1"),
                new Book(2, "Book 2"),
                new Book(3, "Book 3"),
                new Book(1, "Book 1"),
                new Book(2, "Book 2"),
                new Book(3, "Book 3")
            };

            var splitterOptions = new SetSplitterOptions
            {
                MaximumSetSize = 100
            };

            var splitter = new SetSplitter(splitterOptions);

            var result = splitter.Split(books);

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void WhenTwoOneFullSet_AndOnePartialSet_ThenTwoSets()
        {
            var books = new List<Book>()
            {
                new Book(1, "Book 1"),
                new Book(2, "Book 2"),
                new Book(3, "Book 3"),
                new Book(1, "Book 1")
            };

            var splitterOptions = new SetSplitterOptions
            {
                MaximumSetSize = 100
            };

            var splitter = new SetSplitter(splitterOptions);

            var result = splitter.Split(books);

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void WhenOneFullSet_AndTwoPartialSets_ThenTwoSets()
        {
            var books = new List<Book>()
            {
                new Book(1, "Book 1"),
                new Book(1, "Book 1"),
                new Book(2, "Book 2"),
                new Book(2, "Book 2"),
                new Book(3, "Book 3"),
                new Book(3, "Book 3"),
                new Book(4, "Book 4"),
                new Book(5, "Book 5")
            };

            var splitterOptions = new SetSplitterOptions
            {
                MaximumSetSize = 100
            };

            var splitter = new SetSplitter(splitterOptions);

            var result = splitter.Split(books);

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void WithBoundedSetSizeOf1_ThenThreeDifferentBooks_IsThreeDifferentSets()
        {
            var books = new List<Book>()
            {
                new Book(1, "Book 1"),
                new Book(2, "Book 2"),
                new Book(3, "Book 3")
            };

            var splitterOptions = new SetSplitterOptions
            {
                MaximumSetSize = 1
            };

            var splitter = new SetSplitter(splitterOptions);
            var result = splitter.Split(books);

            Assert.AreEqual(3, result.Count);
        }
    }

    public class SetSplitterOptions
    {
        public int MaximumSetSize { get; set; }
    }
}