using System.Collections.Generic;
using System.Linq;

namespace PotterBookshopNetFramework
{
    public class SetSplitter
    {
        public List<SetOfBooks> Split(List<Book> books)
        {
            var sets = new List<SetOfBooks>();

            foreach (var book in books)
            {
                var firstSetWithoutThisBookInIt = sets.FirstOrDefault(x => !x.Books.Any(b => b.BookId == book.BookId));

                if (firstSetWithoutThisBookInIt == null)
                {
                    sets.Add(new SetOfBooks()
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