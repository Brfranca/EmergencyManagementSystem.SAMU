using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class DecisionsMedicalHistoriesMapping : IEntityTypeConfiguration<DecisionsMedicalHistories>
    {
        public void Configure(EntityTypeBuilder<DecisionsMedicalHistories> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.CodeColor).HasColumnName("CodeColor").HasColumnType("smallint").IsRequired();
            builder.Property(d => d.Date).HasColumnName("Date").HasColumnType("datetime").IsRequired();
            builder.Property(d => d.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(150).IsRequired();
            builder.Property(d => d.EmployeeGuid).HasColumnName("EmployeeGuid").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(d => d.EmergencyId).HasColumnName("EmergencyId").HasColumnType("bigint").IsRequired();
        }
    }
}
