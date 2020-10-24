using System.Collections.Generic;
using System.Linq;

namespace PotterBookshopNetFramework
{
    public class SetSplitter
    {
        private SetSplitterOptions options;

        public SetSplitter(SetSplitterOptions splitterOptions)
        {
            options = splitterOptions;
        }

        public List<SetOfBooks> Split(List<Book> books)
        {
            var sets = new List<SetOfBooks>();

            foreach (var book in books)
            {
                var firstSetWithoutThisBookInIt = 
                    sets
                        .Where(x => !x.IsSetFull())
                        .FirstOrDefault(x => !x.Books.Any(b => b.Isbn == book.Isbn));

                if (firstSetWithoutThisBookInIt == null)
                {
                    sets.Add(new SetOfBooks(options.MaximumSetSize)
                    {
                        Books = new List<Book>() {book}
                    });
                }
                else
                {
                    firstSetWithoutThisBookInIt.Books.Add(book);
                }
            }

            return sets;
        }
    }
}