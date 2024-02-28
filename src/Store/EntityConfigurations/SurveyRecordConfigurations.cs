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

        builder.HasMany(x => x.Questions)
            .WithOne()
            .HasForeignKey(x => x.SurveyId);

        builder.HasMany(x => x.Interviews)
            .WithOne()
            .HasForeignKey(x => x.SurveyId);

        builder.HasIndex(x => x.Id)
            .HasDatabaseName("IX_Surveys_Id");

        builder.HasIndex(p => p.Title)
            .HasDatabaseName("UQ_Surveys_Title")
            .IsUnique();

        builder.HasIndex(p => new { p.CreatedAt }).HasDatabaseName("IX_Surveys_CreatedAt");
    }
}