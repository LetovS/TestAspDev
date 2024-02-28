using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;
using Store.EntitiesConfiguration.Extensions;
using Store.EntityConfigurations.Constants;

namespace Store.EntityConfigurations;

public class QuestionRecordConfigurations : IEntityTypeConfiguration<QuestionRecord>
{
    public void Configure(EntityTypeBuilder<QuestionRecord> builder)
    {
        builder.ToTable(ConfigurationSettings.Question.TableName);
        builder.ConfigureIdBaseEntity();

        builder.Property(x => x.Question).IsRequired();

        builder.HasMany(x => x.Answers)
            .WithOne()
            .HasForeignKey(x => x.QuestionId);

        builder.HasIndex(x => x.Id)
            .HasDatabaseName("IX_Questions_Id");

        builder.HasIndex(p => p.Question)
            .HasDatabaseName("UQ_Questions_Question")
            .IsUnique();
    }
}
