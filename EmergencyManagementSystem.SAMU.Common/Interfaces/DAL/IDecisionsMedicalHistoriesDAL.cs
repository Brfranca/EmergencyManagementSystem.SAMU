﻿using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IDecisionsMedicalHistoriesDAL : IBaseDAL<DecisionsMedicalHistories>
    {
        DecisionsMedicalHistories Find(DecisionsMedicalHistoriesFilter filter);
        List<DecisionsMedicalHistories> FindAll(DecisionsMedicalHistoriesFilter filter);
    }
}
