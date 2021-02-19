using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class MedicalEvaluationDAL : BaseDAL<MedicalEvaluation>, IMedicalEvaluationDAL
    {
        public MedicalEvaluationDAL(Context context) : base(context)
        {
        }

        public MedicalEvaluation Find(MedicalEvaluationFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }

        public List<MedicalEvaluation> FindAll(MedicalEvaluationFilter filter)
        {
            var query = Set.AsQueryable();
            if (filter.EmergencyId > 0)
                query = query.Where(d => d.EmergencyId == filter.EmergencyId);

            return query.ToList();
        }
    }
}
