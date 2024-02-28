using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;
using Store.EntitiesConfiguration.Extensions;
using Store.EntityConfigurations.Constants;

namespace Store.EntityConfigurations;

public class ResultRecordConfigurations : IEntityTypeConfiguration<ResultRecord>
{
    public void Configure(EntityTypeBuilder<ResultRecord> builder)
    {
        builder.ToTable(ConfigurationSettings.Result.TableName);
        builder.ConfigureIdBaseEntity();

        builder.Property(x => x.Answer).IsRequired();

        builder.HasIndex(x => x.Id)
            .HasDatabaseName("IX_Results_Id");

        builder.HasIndex(x => x.Answer)
            .HasDatabaseName("UQ_Results_Answer")
            .IsUnique();
    }
}
