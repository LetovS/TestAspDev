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
    }
}
