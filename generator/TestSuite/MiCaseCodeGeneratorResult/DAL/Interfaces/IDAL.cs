using Entities;
using DAL.Interfaces;

namespace DAL
{
    public interface IDAL<T> : ISave<T>, IDelete<T>, IGet<T> where T : BaseEntity
    {

    }
}
