using Entities;

namespace Logic.Interfaces
{
    public interface ILogic<T> : IGet<T>, IDelete<T>, ISave<T> where T : BaseEntity
    {

    }
}
