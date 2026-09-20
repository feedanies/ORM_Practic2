
using ORM_Practic2.DapperReport;
using ORM_Practic2.Data;
using ORM_Practic2.Entities;
using ORM_Practic2.UnitOfWorks;

namespace ORM_Practic2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PublishDBContext context = new PublishDBContext();
            UnitOfWork uf = new UnitOfWork(context);

            Console.WriteLine("===== AUTHOR CRUD =====");

            // CREATE
            Author author = new Author()
            {
                Fullname = "George Orwell",
                Age = 46
            };
            uf.Authors.Add(author);
            Console.WriteLine($"[CREATE] Author -> Id: {author.Id}, Fullname: {author.Fullname}");

            // READ - GetAll
            Console.WriteLine("\n[READ - GetAll] Authors:");
            foreach (var a in uf.Authors.GetAll())
                Console.WriteLine($"  Id: {a.Id}, Fullname: {a.Fullname}, Age: {a.Age}");

            // READ - GetById
            var fetchedAuthor = uf.Authors.GetById(author.Id);
            Console.WriteLine($"\n[READ - GetById] Id {author.Id} -> {(fetchedAuthor != null ? fetchedAuthor.Fullname : "NOT FOUND")}");

            // UPDATE
            if (fetchedAuthor != null)
            {
                fetchedAuthor.Age = 47;
                uf.Authors.Update(fetchedAuthor);
                Console.WriteLine($"\n[UPDATE] Author {fetchedAuthor.Id} -> New Age: {fetchedAuthor.Age}");
            }

            Console.WriteLine("\n===== BOOK CRUD =====");

            // CREATE
            Book book = new Book()
            {
                Title = "1984",
                Genre = "Dystopian",
                AuthorId = author.Id
            };
            uf.Books.Add(book);
            Console.WriteLine($"[CREATE] Book -> Id: {book.Id}, Title: {book.Title}");

            // READ - GetAll
            Console.WriteLine("\n[READ - GetAll] Books:");
            foreach (var b in uf.Books.GetAll())
                Console.WriteLine($"  Id: {b.Id}, Title: {b.Title}, Genre: {b.Genre}, AuthorId: {b.AuthorId}");

            // READ - GetById
            var fetchedBook = uf.Books.GetById(book.Id);
            Console.WriteLine($"\n[READ - GetById] Id {book.Id} -> {(fetchedBook != null ? fetchedBook.Title : "NOT FOUND")}");

            // UPDATE
            if (fetchedBook != null)
            {
                fetchedBook.Genre = "Sci-fi";
                uf.Books.Update(fetchedBook);
                Console.WriteLine($"\n[UPDATE] Book {fetchedBook.Id} -> New Genre: {fetchedBook.Genre}");
            }

            // DELETE - Book first (FK asılılığı üçün)
            if (fetchedBook != null)
            {
                uf.Books.Delete(fetchedBook);
                Console.WriteLine($"\n[DELETE] Book {fetchedBook.Id} deleted.");
            }

            // DELETE - Author
            if (fetchedAuthor != null)
            {
                uf.Authors.Delete(fetchedAuthor);
                Console.WriteLine($"[DELETE] Author {fetchedAuthor.Id} deleted.");
            }

            Console.WriteLine("\n===== FINAL STATE =====");
            Console.WriteLine("Authors remaining: " + uf.Authors.GetAll().Count());
            Console.WriteLine("Books remaining: " + uf.Books.GetAll().Count());

            uf.Dispose();

            Console.WriteLine("\n===== DAPPER REPORT (Author + Books) =====");
            Report report = new Report();
            var authors = report.GetAuthorBooks();
            foreach (var a in authors)
            {
                Console.WriteLine($"Fullname: {a.Fullname}, Age: {a.Age}");
                foreach (var b in a.Books)
                {
                    Console.WriteLine($"  Title: {b.Title}, Genre: {b.Genre}");
                }
                Console.WriteLine();
            }
        }
    }
}

