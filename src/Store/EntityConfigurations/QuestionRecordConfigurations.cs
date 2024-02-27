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
    }
}
