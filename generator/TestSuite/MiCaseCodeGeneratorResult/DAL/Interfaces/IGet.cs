using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGet<out T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(int id);
    }
}
