using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class MemberDAL : BaseDAL<Member>, IMemberDAL
    {
        public MemberDAL(Context context) : base(context)
        {

        }
        public Member Find(MemberFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }

        public List<Member> FindAll(MemberFilter filterImpl)
        {
            var query = Set.AsQueryable();

            if (filterImpl.EmployeeStatus != Entities.Enums.EmployeeStatus.Invalid)
                query = query.Where(d => d.EmployeeStatus == filterImpl.EmployeeStatus);
            if (filterImpl.VehicleId > 0)
                query = query.Where(d => d.VehicleId == filterImpl.VehicleId);

            return query.ToList();
        }
    }
}
