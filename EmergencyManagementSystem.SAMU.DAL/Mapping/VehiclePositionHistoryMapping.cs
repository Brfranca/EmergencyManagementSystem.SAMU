using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class VehiclePositionHistoryMapping : IEntityTypeConfiguration<VehiclePositionHistory>
    {
        public void Configure(EntityTypeBuilder<VehiclePositionHistory> builder)
        {
            builder.ToTable("VehiclePositionHistories", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(d => d.VehiclePosition)
                .HasColumnName("VehiclePosition")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(d => d.ServiceHistory)
                .WithMany(d => d.VehiclePositionHistories)
                .HasForeignKey(d => d.ServiceHistoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
