using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Filters
{
    public class FilterBase : IFilter
    {
        public int CurrentPage { get; set; }
    }
}
