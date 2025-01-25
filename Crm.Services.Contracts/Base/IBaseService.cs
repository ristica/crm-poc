namespace Crm.Services.Contracts.Base;

public interface IBaseService<T>
{
    void ValidateModelDataAnnotations(T model);

    T Get(int id);
    void UpdateOrCreate(T model);
    void Delete(int id);
    IEnumerable<T> GetAll();
}