using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISave<in T> where T : BaseEntity
    {
        int Save(T entity);

        int Update(T entity);
    }
}
