using ORM_Practic2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.DapperReport
{
    public class BookDapper
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int AuthorId { get; set; }
        public AuthorDapper Author { get; set; }
    }
}
