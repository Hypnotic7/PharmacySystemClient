using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemDataAccess.Repository
{
    public interface IDataAccessFindAll<T> : IDataAccess<T>
    {
        List<T> FindAll();
    }
}
