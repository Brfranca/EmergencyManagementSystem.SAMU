﻿using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class Vehicle : IEntity<long>
    {
        public long Id { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleName { get; set; }
        public int Year { get; set; }
        public VehicleType VehicleType { get; set; }
        public VehicleSituation VehicleSituation { get; set; }
        public ICollection<VehicleTeam> VehicleTeams { get; set; }
    }
}
