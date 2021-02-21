using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Filters
{
    public class DecisionsMedicalHistoriesFilter : FilterBase
    {
        public long EmergencyId { get; set; }
    }
}
