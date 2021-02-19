using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class EmergencyDAL : BaseDAL<Emergency>, IEmergencyDAL
    {
        public EmergencyDAL(Context context) : base(context)
        {
        }

        public Emergency Find(EmergencyFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }

        public List<Emergency> FindAll(EmergencyFilter filter)
        {
            var query = Set.AsQueryable();
            if (filter.Id > 0)
                query = query.Where(d => d.Id == filter.Id);
            if (filter.EmergencyStatus != Entities.Enums.EmergencyStatus.Invalid)
                query = query.Where(d => d.EmergencyStatus == filter.EmergencyStatus);
            if (filter.EmergenciesStatus.Count() > 0)
                query = query.Where(d => filter.EmergenciesStatus.Contains(d.EmergencyStatus));

            return query.ToList();
        }
    }
}
