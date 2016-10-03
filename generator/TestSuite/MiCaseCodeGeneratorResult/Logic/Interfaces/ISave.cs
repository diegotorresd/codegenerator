using Entities;

namespace Logic.Interfaces
{
    public interface ISave<T> where T : BaseEntity
    {
        int Save(T entity);
    }
}
