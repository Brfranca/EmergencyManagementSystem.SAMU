using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class MedicalDecisionHistoryMapping : IEntityTypeConfiguration<MedicalDecisionHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalDecisionHistory> builder)
        {
            builder.ToTable("MedicalDecisionHistories", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.CodeColor)
                .HasColumnName("CodeColor")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.EmployeeGuid)
                .HasColumnName("EmployeeGuid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(d => d.EmergencyId)
                .HasColumnName("EmergencyId")
                .HasColumnType("bigint")
                .IsRequired();

            builder.Property(d => d.EmployeeName)
                .HasColumnName("EmployeeName")
                .HasColumnType("vachar")
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
