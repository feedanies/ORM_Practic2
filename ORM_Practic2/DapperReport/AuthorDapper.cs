using ORM_Practic2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.DapperReport
{
    public class AuthorDapper
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public int Age { get; set; }
        public ICollection<BookDapper> Books { get; set; }
        public AuthorDapper()
        {
            Books = new List<BookDapper>();
        }
    }
}
