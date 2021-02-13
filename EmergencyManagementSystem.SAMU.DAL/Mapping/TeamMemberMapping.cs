using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.SAMU.DAL.Mapping
{
    public class TeamMemberMapping : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.ToTable("TeamMembers", "dbo");

            builder.HasKey(d => d.Id);

            builder.HasOne(e => e.Member)
                .WithMany()
                .HasForeignKey(e => e.MemberId)
                .IsRequired();

            builder.HasOne(e => e.ServiceHistory)
                .WithMany(e => e.TeamMembers)
                .HasForeignKey(e => e.ServiceHistoryId)
                .IsRequired();
        }
    }
}
