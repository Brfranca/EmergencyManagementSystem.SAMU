using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class ServiceHistoryMapping : IEntityTypeConfiguration<ServiceHistory>
    {
        public void Configure(EntityTypeBuilder<ServiceHistory> builder)
        {
            builder.ToTable("ServiceHistories", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(d => d.Emergency)
                .WithMany(d => d.ServiceHistories)
                .HasForeignKey(d => d.EmergencyId);

            builder.HasOne(d => d.Vehicle)
                .WithMany(d => d.ServiceHistories)
                .HasForeignKey(d => d.VehicleId);

            builder.Property(d => d.ServiceHistoryStatus)
                .HasColumnName("ServiceHistoryStatus")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
