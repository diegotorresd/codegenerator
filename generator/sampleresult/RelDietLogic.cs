using Entities;
using DAL;

namespace Logic
{
    public partial class RelDietLogic : BaseLogic<RelDietEntity>
    {
        public RelDietLogic(IDAL<RelDietEntity> dal) : base(dal)
        {

        }
    }
}