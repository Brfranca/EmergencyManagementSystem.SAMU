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
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(d => d.EmergencyStatus)
                .HasColumnName("EmergencyStatus")
                .HasColumnType("int")
                .IsRequired();

            builder.HasMany(d => d.EmergencyDatas)
                .WithOne(d => d.Emergency);

            builder.HasMany(d => d.EmergencyHistories)
                .WithOne(d => d.Emergency);

            builder.HasMany(d => d.MedicalEvaluations)
                .WithOne(d => d.Emergency);

            builder.HasMany(d => d.Patients)
                .WithOne(d => d.Emergency);

            builder.HasMany(d => d.VehicleTeams)
                .WithOne(d => d.Emergency);





        }
    }
}
