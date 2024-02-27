using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;
using Store.EntitiesConfiguration.Extensions;
using Store.EntityConfigurations.Constants;

namespace Store.EntityConfigurations;

public class SurveyRecordConfigurations : IEntityTypeConfiguration<SurveyRecord>
{
    public void Configure(EntityTypeBuilder<SurveyRecord> builder)
    {
        builder.ToTable(ConfigurationSettings.Survey.TableName);
        builder.ConfigureIdBaseEntity();

        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(ConfigurationSettings.Survey.MaxDescriptionLength);

        builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
        builder.Property(x => x.StartDate).HasDefaultValue(DateTime.UtcNow);
        builder.Property(x => x.EndDate).HasDefaultValue(DateTime.UtcNow.AddDays(14));
    }
}