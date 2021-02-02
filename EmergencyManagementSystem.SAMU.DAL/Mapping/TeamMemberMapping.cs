using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class TeamMemberMapping : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.ToTable("TeamMembers", "dbo");

            builder.Property(d => d.EmployeeGuid)
                .HasColumnName("EmployeeGuid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(d => d.VehicleTeam)
                .WithMany()
                .HasForeignKey(d => d.VehicleTeamId);
        }
    }
}
