using Dapper;
using Microsoft.Data.SqlClient;
using ORM_Practic2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.DapperReport
{
    public class Report
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PublishDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        public IEnumerable<Author> GetAuthorBooks()
        {
            string sql = @"SELECT A.Fullname,A.Age,B.AuthorId,B.Title,B.Genre
                            FROM Authors AS A
                            INNER JOIN Books AS B
                            ON A.Id=B.AuthorId";

            using (var connection=new SqlConnection(connectionString))
            {
                return connection.Query<AuthorDapper, BookDapper, AuthorDapper>(sql, (a, b) =>
                {
                    a.Books.Add(b);
                    b.Author = a;
                    return a;
                }, splitOn: nameof(BookDapper.AuthorId);
            }
        }

    }
}
