using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class ServiceHistoryDAL : BaseDAL<ServiceHistory>, IServiceHistoryDAL
    {
        public ServiceHistoryDAL(Context context) : base(context)
        {
        }

        public ServiceHistory Find(ServiceHistoryFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
