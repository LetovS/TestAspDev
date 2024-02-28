using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;
using Store.EntitiesConfiguration.Extensions;
using Store.EntityConfigurations.Constants;

namespace Store.EntityConfigurations;

public class AnswerRecordConfigurations : IEntityTypeConfiguration<AnswerRecord>
{
    public void Configure(EntityTypeBuilder<AnswerRecord> builder)
    {
        builder.ToTable(ConfigurationSettings.Answer.TableName);
        builder.ConfigureIdBaseEntity();

        builder.Property(x => x.Answer).IsRequired();

        builder.HasIndex(x => x.Id)
            .HasDatabaseName("IX_Answers_Id");

        builder.HasIndex(p => p.Answer)
            .HasDatabaseName("UQ_Answers_Answer")
            .IsUnique();
    }
}
