using EmergencyManagementSystem.SAMU.DAL.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new EmergencyHistoryMapping());
            modelBuilder.ApplyConfiguration(new EmergencyMapping());
            modelBuilder.ApplyConfiguration(new EmergencyRequiredVehicleMapping());
            modelBuilder.ApplyConfiguration(new TeamMemberMapping());
            modelBuilder.ApplyConfiguration(new VehicleMapping());
            modelBuilder.ApplyConfiguration(new VehiclePositionHistoryMapping());
            modelBuilder.ApplyConfiguration(new VehicleTeamMapping());
            modelBuilder.ApplyConfiguration(new MedicalEvaluationMapping());
            modelBuilder.ApplyConfiguration(new PatientMapping());

        }

        //usar apenas para criar a migration
        public class ContextFactory : IDesignTimeDbContextFactory<Context>
        {
            public Context CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=EMS-SAMU;Integrated Security=true");

                return new Context(optionsBuilder.Options);
            }
        }
    }
}
