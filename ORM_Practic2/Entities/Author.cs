using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }
    }
}
