using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemDataAccess.Repository
{
    public interface IDataAccess<T>
    {
        string CollectionName { get; }
        void Add(T entity);
        void Remove(T entity);
        void Modify(T entity);

        T Find(string id);
    }
}
