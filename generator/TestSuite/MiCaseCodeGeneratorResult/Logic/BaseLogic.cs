using DAL;
using Entities;
using Logic.Interfaces;
using System.Collections.Generic;


namespace Logic
{
    public abstract class BaseLogic<T> : ILogic<T> where T : BaseEntity
    {
        private IDAL<T> Dal;

        protected BaseLogic() { }

        public BaseLogic(IDAL<T> dal)
        {
            this.Dal = dal;
        }

        public virtual T Get(int id)
        {
            var entity = Dal.Get(id);
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var list = Dal.GetAll();

            return list;
        }

        public virtual int Save(T entity)
        {
            if (entity.Id == 0)
                return Dal.Save(entity); 

            return Dal.Update(entity); 
        }

        public void Delete(int id)
        {
            Dal.Delete(id);
        }
    }
}
