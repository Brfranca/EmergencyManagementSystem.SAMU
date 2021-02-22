using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class MedicalEvaluationMapping : IEntityTypeConfiguration<MedicalEvaluation>
    {
        public void Configure(EntityTypeBuilder<MedicalEvaluation> builder)
        {
            builder.ToTable("MedicalEvaluations", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(d => d.Emergency)
                .WithMany(d => d.MedicalEvaluations)
                .HasForeignKey(d => d.EmergencyId);

            builder.Property(d => d.EmployeeGuid)
                .HasColumnName("EmployeeGuid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(d => d.Evaluation)
                .HasColumnName("Evaluation")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(d => d.Patient)
                .WithMany(d => d.MedicalEvaluations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.EmployeeName)
                .HasColumnName("EmployeeName")
                .HasColumnType("vachar")
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
