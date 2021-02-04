using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class VehicleTeamMapping : IEntityTypeConfiguration<VehicleTeam>
    {
        public void Configure(EntityTypeBuilder<VehicleTeam> builder)
        {
            builder.ToTable("VehicleTeams", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(d => d.Emergency)
                .WithMany()
                .HasForeignKey(d => d.EmergencyId);

            builder.HasOne(d => d.Vehicle)
                .WithMany()
                .HasForeignKey(d => d.VehicleId);

            builder.Property(d => d.VehicleTeamStatus)
                .HasColumnName("VehicleTeamStatus")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasMany(d => d.TeamMembers)
                .WithOne()
                .HasForeignKey(d => d.VehicleTeamId);

            builder.HasMany(d => d.VehiclePositionHistories)
                .WithOne()
                .HasForeignKey(d => d.VehicleTeamId);

        }
    }
}
