using Entities;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IGet<out T> where T : BaseEntity 
    {
        T Get(int id);

        IEnumerable<T> GetAll();
    }
}
