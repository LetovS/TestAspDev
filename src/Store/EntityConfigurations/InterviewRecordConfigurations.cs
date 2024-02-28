using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;
using Store.EntitiesConfiguration.Extensions;
using Store.EntityConfigurations.Constants;

namespace Store.EntityConfigurations;

public class InterviewRecordConfigurations : IEntityTypeConfiguration<InterviewRecord>
{
    public void Configure(EntityTypeBuilder<InterviewRecord> builder)
    {
        builder.ToTable(ConfigurationSettings.Interview.TableName);
        builder.ConfigureIdBaseEntity();

        builder.Property(x => x.InterviewDate).HasDefaultValue(DateTime.UtcNow);

        builder.HasMany(x => x.Results)
            .WithOne()
            .HasForeignKey(x => x.InterviewId);

        builder.HasIndex(x => x.Id)
            .HasDatabaseName("IX_Interviews_Id");

        builder.HasIndex(p => new { p.InterviewDate }).HasDatabaseName("IX_Interviews_InterviewDate");
    }
}
