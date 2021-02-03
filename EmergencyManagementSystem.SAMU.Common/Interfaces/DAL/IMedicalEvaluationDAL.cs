using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IMedicalEvaluationDAL : IBaseDAL<MedicalEvaluation>
    {
        MedicalEvaluation Find(MedicalEvaluationFilter filter);
    }
}
