using System.Collections.Generic;

namespace PharmacySystemDataAccess.Repository
{
    public interface IDataAccessFindAll<T> : IDataAccess<T>
    {
        List<T> FindAll();
    }
}
