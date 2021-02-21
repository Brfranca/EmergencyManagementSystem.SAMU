using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.BLL
{
    public interface IMedicalEvaluationBLL : IBaseBLL<MedicalEvaluationModel, MedicalEvaluation>
    {
        Result RegisterEvaluations(List<MedicalEvaluationModel> evaluations);
    }
}
