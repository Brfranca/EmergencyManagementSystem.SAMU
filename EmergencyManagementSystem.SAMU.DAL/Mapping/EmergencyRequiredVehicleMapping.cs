using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class EmergencyRequiredVehicleMapping : IEntityTypeConfiguration<EmergencyRequiredVehicle>
    {
        public void Configure(EntityTypeBuilder<EmergencyRequiredVehicle> builder)
        {
            builder.ToTable("EmergencyRequiredVehicles", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(d => d.VehicleType)
                .HasColumnName("VehicleType")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.CodeColor)
                .HasColumnName("CodeColor")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(d => d.Emergency)
                .WithMany(d => d.EmergencyRequiredVehicles)
                .HasForeignKey(d => d.EmergencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.Status)
                .HasColumnName("Status")
                .HasColumnType("smallint")
                .IsRequired();
        }
    }
}
