using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class EmergencyHistoryMapping : IEntityTypeConfiguration<EmergencyHistory>
    {
        public void Configure(EntityTypeBuilder<EmergencyHistory> builder)
        {
            builder.ToTable("EmergencyHistories", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(d => d.Emergency)
                .WithMany(d => d.EmergencyHistories)
                .HasForeignKey(d => d.EmergencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.EmergencyStatus)
                .HasColumnName("EmergencyStatus")
                .HasColumnType("int")
                .IsRequired();


            builder.Property(d => d.EmployeeGuid)
                .HasColumnName("EmployeeGuid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();
        }
    }
}
