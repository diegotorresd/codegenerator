using Entities;

namespace DAL.Interfaces
{
    public interface IDelete<T> where T : BaseEntity
    {
        bool Delete(int id);
    }
}
