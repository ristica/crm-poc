namespace Crm.Services.Contracts
{
    public interface IBooksService<T>
    {
        void ValidateModelDataAnnotations(T model);

        T Get(int id);
        void UpdateOrCreate(T model);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
