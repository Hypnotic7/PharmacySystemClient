using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemDataAccess.Repository;

namespace PharmacySystemBusinessLogic.RepositoryFactory
{
    public interface IRepositoryFactory<T>
    {
        IDataAccess<T> CreateRepository(string connectionString, string type);
    }
}
