using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class MedicalDecisionHistoryDAL : BaseDAL<MedicalDecisionHistory>, IMedicalDecisionHistoryDAL
    {
        public MedicalDecisionHistoryDAL(Context context) : base(context)
        {
        }

        public MedicalDecisionHistory Find(MedicalDecisionHistoryFilter filter)
        {
            var query = Set.AsQueryable();

            if (filter.EmergencyId > 0)
                query = query.Where(d => d.EmergencyId == filter.EmergencyId);

            return query.FirstOrDefault();
        }

        public List<MedicalDecisionHistory> FindAll(MedicalDecisionHistoryFilter filter)
        {
            var query = Set.AsQueryable();

            if (filter.EmergencyId > 0)
                query = query.Where(d => d.EmergencyId == filter.EmergencyId);

            return query.ToList();
        }
    }
}
