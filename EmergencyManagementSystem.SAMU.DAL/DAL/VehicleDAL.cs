using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class VehicleDAL : BaseDAL<Vehicle>, IVehicleDAL
    {
        public VehicleDAL(Context context) : base(context)
        {
        }

        public Vehicle Find(VehicleFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
