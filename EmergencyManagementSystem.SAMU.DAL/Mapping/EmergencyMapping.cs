using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class EmergencyMapping : IEntityTypeConfiguration<Emergency>
    {
        public void Configure(EntityTypeBuilder<Emergency> builder)
        {
            builder.ToTable("Emergencies", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(d => d.RequesterName)
                .HasColumnName("RequesterName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.RequesterPhone)
                .HasColumnName("RequesterPhone")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.EmergencyStatus)
                .HasColumnName("EmergencyStatus")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(d => d.Address)
                .WithMany()
                .HasForeignKey(d => d.AddressId);

            builder.HasMany(d => d.EmergencyHistories)
                .WithOne(d => d.Emergency);

            builder.HasMany(d => d.MedicalEvaluations)
                .WithOne(d => d.Emergency);

            builder.HasMany(d => d.Patients)
                .WithOne(d => d.Emergency);

            builder.HasMany(d => d.VehicleTeams)
                .WithOne(d => d.Emergency);

            builder.HasMany(d => d.EmergencyRequiredVehicles)
                .WithOne(d => d.Emergency);
        }
    }
}
