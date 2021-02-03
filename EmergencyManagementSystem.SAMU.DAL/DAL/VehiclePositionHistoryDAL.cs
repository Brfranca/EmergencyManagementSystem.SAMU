using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
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
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
