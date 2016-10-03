using System.Data;

namespace Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsNew { get; private set; }
        
        protected BaseEntity()
        {
            IsNew = true;
        }
        public BaseEntity(IDataRecord dataRecord)
        {
            IsNew = false;
            Id = (int)dataRecord["ID"];
        }
    }
}




