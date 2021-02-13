using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class MemberMapping : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.EmployeeGuid)
                .HasColumnName("EmployeeGuid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(d => d.Vehicle)
                .WithMany()
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.EmployeeStatus)
                .HasColumnName("EmployeeStatus")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.StartedWork)
                .HasColumnName("StartedWork")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(d => d.FinishedWork)
                .HasColumnName("FinishedWork")
                .HasColumnType("datetime");
        }
    }
}
