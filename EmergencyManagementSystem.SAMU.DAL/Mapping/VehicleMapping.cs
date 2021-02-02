﻿using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Plaque)
                .HasColumnName("Plaque")
                .HasColumnType("varchar")
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(d => d.VehicleName)
                .HasColumnName("VehicleName")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(d => d.VehicleSituation)
                .HasColumnName("VehicleSituation")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.VehicleType)
                .HasColumnName("VehicleType")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.Year)
                .HasColumnName("Year")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
