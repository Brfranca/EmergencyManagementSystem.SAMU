﻿using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Filters
{
    public class PatientFilter : IFilter
    {
        public long Id { get; set; }
    }
}
