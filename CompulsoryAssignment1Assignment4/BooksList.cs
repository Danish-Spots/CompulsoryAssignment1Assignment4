using System;
using System.Collections.Generic;
using System.Text;
using CompulsoryAssignment1Assignment1;

namespace CompulsoryAssignment1Assignment4
{
    public static class BooksList
    {
        public static List<Book> books = new List<Book>()
        {
            new Book("To Kill A Mockingbird", "Harper Lee", 296, "9780446310789"),
            new Book("The Runaway Jury", "John Grisham", 414, "9780440221470"),
            new Book("My Youth Romantic Comedy Is Wrong, As I Expected Vol 1", "Wataru Watari", 231, "9780316312295")
        };
    }
}
