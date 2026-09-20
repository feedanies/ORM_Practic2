using ORM_Practic2.Data;
using ORM_Practic2.Entities;
using ORM_Practic2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.Repository.Concrete
{
    public class AuthorRepository : IAuthorRepositoryInterface
    {
        private readonly PublishDBContext _context;

        public AuthorRepository(PublishDBContext context)
        {
            _context = context;
        }

        public void Add(Author obj)
        {
            _context.Authors.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Author obj)
        {
            _context.Authors.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public Author? GetById(int id)
        {
            return _context.Authors.SingleOrDefault(a => a.Id == id);
        }

        public void Update(Author obj)
        {
            _context.Authors.Update(obj);
            _context.SaveChanges();
        }
    }
}
