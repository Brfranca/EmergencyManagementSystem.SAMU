using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class VehicleTeamDAL : BaseDAL<VehicleTeam>, IVehicleTeamDAL
    {
        public VehicleTeamDAL(Context context) : base(context)
        {
        }

        public VehicleTeam Find(VehicleTeamFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
