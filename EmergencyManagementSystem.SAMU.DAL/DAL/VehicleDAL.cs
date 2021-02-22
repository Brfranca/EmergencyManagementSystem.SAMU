using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System.Collections.Generic;
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

            if (!string.IsNullOrWhiteSpace(filter.VehicleName))
                query = query.Where(d => d.VehicleName.Contains(filter.VehicleName));

            if (!string.IsNullOrWhiteSpace(filter.VehiclePlate))
                query = query.Where(d => d.VehiclePlate == filter.VehiclePlate);

            if ((filter?.VehicleStatus ?? VehicleStatus.Invalido) != VehicleStatus.Invalido)
                query = query.Where(d => d.VehicleStatus == filter.VehicleStatus);

            if ((filter?.VehicleType ?? VehicleType.Invalido) != VehicleType.Invalido)
                query = query.Where(d => d.VehicleType == filter.VehicleType);

            if (filter.Active != null)
                query = query.Where(d => d.Active == filter.Active);

            return query.FirstOrDefault();
        }

        public List<Vehicle> FindAll(VehicleFilter filter)
        {
            var query = Set.AsQueryable();
            if (filter.Id > 0)
                query = query.Where(d => d.Id == filter.Id);

            if (!string.IsNullOrWhiteSpace(filter.VehicleName))
                query = query.Where(d => d.VehicleName.Contains(filter.VehicleName));

            if (!string.IsNullOrWhiteSpace(filter.VehiclePlate))
                query = query.Where(d => d.VehiclePlate == filter.VehiclePlate);

            if ((filter?.VehicleStatus ?? VehicleStatus.Invalido) != VehicleStatus.Invalido)
                query = query.Where(d => d.VehicleStatus == filter.VehicleStatus);

            if ((filter?.VehicleType ?? VehicleType.Invalido) != VehicleType.Invalido)
                query = query.Where(d => d.VehicleType == filter.VehicleType);

            if (filter.Active != null)
                query = query.Where(d => d.Active == filter.Active);

            return query.ToList();
        }
    }
}
