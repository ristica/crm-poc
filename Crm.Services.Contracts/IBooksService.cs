namespace Crm.Services.Contracts
{
    public interface IBooksService<T>
    {
        void ValidateModelDataAnnotations(T model);

        T Get(string isbn);
        void UpdateOrCreate(T model);
        void Delete(string isbn);
        IEnumerable<T> GetAll();
    }
}
