﻿using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Filters
{
    public class EmergencyHistoryFilter : FilterBase
    {
        public long Id { get; set; }
        public long EmergencyId { get; set; }
        public EmergencyStatus? EmergencyStatus { get; set; }
    }
}
