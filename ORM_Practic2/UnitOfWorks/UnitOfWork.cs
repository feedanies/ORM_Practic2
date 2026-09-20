using ORM_Practic2.Data;
using ORM_Practic2.Repository.Concrete;
using ORM_Practic2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.UnitOfWorks
{
    public class UnitOfWork : IDisposable
    {
        private readonly PublishDBContext _context;

        public UnitOfWork(PublishDBContext context)
        {
            _context = context;
            Authors = new AuthorRepository(context);
            Books = new BookRepository(context);
        }

        public IAuthorRepositoryInterface Authors { get; }
        public IBookRepositoryInterface Books { get; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
