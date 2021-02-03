﻿using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class EmergencyHistoryDAL : BaseDAL<EmergencyHistory>, IEmergencyHistoryDAL
    {
        public EmergencyHistoryDAL(Context context) : base(context)
        {
        }

        public EmergencyHistory Find(EmergencyHistoryFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
