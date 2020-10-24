using System.Collections.Generic;

namespace PotterBookshopNetFramework
{
    public class SetOfBooks
    {
        public int SetSize { get; set; }
        public List<Book> Books { get; set; }

        public SetOfBooks(int setSize)
        {
            SetSize = setSize;
        }

        public bool IsSetFull() => Books.Count >= SetSize;
    }
}