using ORM_Practic2.Data;
using ORM_Practic2.Entities;
using ORM_Practic2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.Repository.Concrete
{
    public class BookRepository : IBookRepositoryInterface
    {
        private readonly PublishDBContext _context;

        public BookRepository(PublishDBContext context)
        {
            _context = context;
        }

        public void Add(Book obj)
        {
            _context.Books.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Book obj)
        {
            _context.Books.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books();
        }

        public Book? GetById(int id)
        {
            return _context.Books.SingleOrDefault(b => b.Id == id);
        }

        public void Update(Book obj)
        {
            _context.Books.Update(obj);
            _context.SaveChanges();
        }
    }
}
