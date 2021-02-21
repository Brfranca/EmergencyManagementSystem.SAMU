using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IMedicalDecisionHistoryDAL : IBaseDAL<MedicalDecisionHistory>
    {
        MedicalDecisionHistory Find(MedicalDecisionHistoryFilter filter);
        List<MedicalDecisionHistory> FindAll(MedicalDecisionHistoryFilter filter);
    }
}
