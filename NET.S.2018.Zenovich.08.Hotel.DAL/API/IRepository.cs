using System;
using System.Collections.Generic;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.API
{
    public interface IRepository<T>
    {
        void Create(T entity);

        void Delete(Guid id);

        T Get(Guid id);

        List<T> GetAll();

        void Save();

        void Update(T entity);
    }
}