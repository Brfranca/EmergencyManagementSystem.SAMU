using EmergencyManagementSystem.SAMU.DAL.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmergencyMapping());
            modelBuilder.ApplyConfiguration(new VehicleMapping());
            modelBuilder.ApplyConfiguration(new VehiclePositionHistoryMapping());
            modelBuilder.ApplyConfiguration(new EmergencyDataMapping());
            modelBuilder.ApplyConfiguration(new VehicleTeamMapping());

        }
    }
}
