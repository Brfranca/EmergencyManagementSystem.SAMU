using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class EmergencyDAL: BaseDAL<Emergency>, IEmergencyDAL
    {
        public EmergencyDAL(Context context) : base(context)
        {
        }

        public Emergency Find(EmergencyFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
