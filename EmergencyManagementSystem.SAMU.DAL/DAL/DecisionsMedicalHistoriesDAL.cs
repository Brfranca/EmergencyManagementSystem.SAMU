using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class DecisionsMedicalHistoriesDAL : BaseDAL<DecisionsMedicalHistories>, IDecisionsMedicalHistoriesDAL
    {
        public DecisionsMedicalHistoriesDAL(Context context) : base(context)
        {
        }

        public DecisionsMedicalHistories Find(DecisionsMedicalHistoriesFilter filter)
        {
            var query = Set.AsQueryable();

            if (filter.EmergencyId > 0)
                query = query.Where(d => d.EmergencyId == filter.EmergencyId);

            return query.FirstOrDefault();
        }

        public List<DecisionsMedicalHistories> FindAll(DecisionsMedicalHistoriesFilter filter)
        {
            var query = Set.AsQueryable();

            if (filter.EmergencyId > 0)
                query = query.Where(d => d.EmergencyId == filter.EmergencyId);

            return query.ToList();
        }
    }
}
