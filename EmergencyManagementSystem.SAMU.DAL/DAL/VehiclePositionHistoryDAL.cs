using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class VehiclePositionHistoryDAL : BaseDAL<VehiclePositionHistory>, IVehiclePositionHistoryDAL
    {
        public VehiclePositionHistoryDAL(Context context) : base(context)
        {
        }

        public VehiclePositionHistory Find(VehiclePositionHistoryFilter filter)
        {
            var query = Set.AsQueryable();

            if (filter.Id > 0)
                query = query.Where(d => d.Id == filter.Id);

            if (filter.ServiceHistoryId > 0)
                query = query.Where(d => d.ServiceHistoryId == filter.ServiceHistoryId);

            if (filter.VehiclePosition != null && filter.VehiclePosition != VehiclePosition.Invalid)
                query = query.Where(d => d.VehiclePosition == filter.VehiclePosition);

            return query.FirstOrDefault();
        }
    }
}
