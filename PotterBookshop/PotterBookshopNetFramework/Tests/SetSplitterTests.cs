using System.Collections.Generic;
using NUnit.Framework;

namespace PotterBookshopNetFramework.Tests
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

        [TestCase(1, 5)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        [TestCase(4, 2)]
        [TestCase(5, 1)]
        public void WithBoundedSetSizeOf1_ThenThreeDifferentBooks_IsThreeDifferentSets(int setSize, int expectedSplitCount)
        {
            var books = new List<Book>()
            {
                new Book(1, "Book 1"),
                new Book(2, "Book 2"),
                new Book(3, "Book 3"),
                new Book(4, "Book 4"),
                new Book(5, "Book 5")
            };

            var splitterOptions = new SetSplitterOptions
            {
                MaximumSetSize = setSize
            };

            var splitter = new SetSplitter(splitterOptions);
            var result = splitter.Split(books);

            Assert.AreEqual(expectedSplitCount, result.Count);
        }
    }
}