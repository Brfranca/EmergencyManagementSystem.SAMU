using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class EmergencyDataMapping : IEntityTypeConfiguration<EmergencyData>
    {
        public void Configure(EntityTypeBuilder<EmergencyData> builder)
        {
            builder.ToTable("EmergencyDatas", "dbo");


        }
    }
}
