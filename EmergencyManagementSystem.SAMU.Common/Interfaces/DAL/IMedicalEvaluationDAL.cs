using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IMedicalEvaluationDAL : IBaseDAL<MedicalEvaluation>
    {
        MedicalEvaluation Find(MedicalEvaluationFilter filter);

        List<MedicalEvaluation> FindAll(MedicalEvaluationFilter filter);
    }
}
