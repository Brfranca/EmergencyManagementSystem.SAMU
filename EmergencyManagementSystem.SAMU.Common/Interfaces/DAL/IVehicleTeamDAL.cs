using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Entities.Entities;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IVehicleTeamDAL : IBaseDAL<VehicleTeam>
    {
        VehicleTeam Find(VehicleTeamFilter filter);
    }
}
