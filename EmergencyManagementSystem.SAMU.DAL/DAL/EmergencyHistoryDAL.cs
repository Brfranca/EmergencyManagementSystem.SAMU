using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class EmergencyHistoryDAL : BaseDAL<EmergencyHistory>, IEmergencyHistoryDAL
    {
        public EmergencyHistoryDAL(Context context) : base(context)
        {
        }

        public EmergencyHistory Find(EmergencyHistoryFilter filter)
        {
            var query = Set.AsQueryable();

            if (filter.Id > 0)
                query = query.Where(d => d.Id == filter.Id);

            if (filter.EmergencyId > 0)
                query = query.Where(d => d.EmergencyId == filter.EmergencyId);

            if (filter.EmergencyStatus != null && filter.EmergencyStatus != Entities.Enums.EmergencyStatus.Invalid)
                query = query.Where(d => d.EmergencyStatus == filter.EmergencyStatus);

            return query.FirstOrDefault();
        }
    }
}
