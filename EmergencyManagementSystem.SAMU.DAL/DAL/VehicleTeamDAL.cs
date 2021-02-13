using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class VehicleTeamDAL : BaseDAL<ServiceHistory>, IVehicleTeamDAL
    {
        public VehicleTeamDAL(Context context) : base(context)
        {
        }

        public ServiceHistory Find(VehicleTeamFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
