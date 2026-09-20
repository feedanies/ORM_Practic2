using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.Repository.Interfaces
{
    public interface IRepository<T> where T:class
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
