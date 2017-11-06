namespace PharmacySystemDataAccess.Repository.RepositoryFactory
{
    public interface IRepositoryFactory<T>
    {
        IDataAccess<T> CreateRepository(string connectionString, string type);
    }
}
