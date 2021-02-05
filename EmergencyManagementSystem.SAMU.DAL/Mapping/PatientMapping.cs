using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Telephone)
                .HasColumnName("Telephone")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.Age)
                .HasColumnName("Age")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.Gender)
                .HasColumnName("Gender")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(d => d.Emergency)
                .WithMany(d => d.Patients)
                .HasForeignKey(d => d.EmergencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
