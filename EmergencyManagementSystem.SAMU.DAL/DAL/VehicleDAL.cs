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
            var query = Set.AsQueryable();
            if (filter.Id > 0)
                query = query.Where(d => d.Id == filter.Id);

            else if (!string.IsNullOrWhiteSpace(filter.VehicleName))
                query = query.Where(d => d.VehicleName.Contains(filter.VehicleName));

            else if (!string.IsNullOrWhiteSpace(filter.VehiclePlate))
                query = query.Where(d => d.VehiclePlate == filter.VehiclePlate);

            return query.FirstOrDefault();
        }
    }
}
