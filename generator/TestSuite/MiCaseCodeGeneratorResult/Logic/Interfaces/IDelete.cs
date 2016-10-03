using Entities;

namespace Logic.Interfaces
{
    public interface IDelete<T> where T : BaseEntity
    {
        void Delete(int id);
    }
}
