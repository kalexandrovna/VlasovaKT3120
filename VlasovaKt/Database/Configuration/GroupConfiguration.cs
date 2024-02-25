using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VlasovaKt.Models;

namespace VlasovaKt.Database.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "group";
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(p => p.GroupId)
                .HasName($"pk_{TableName}_group_id");

            builder.Property(p => p.GroupId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи группы");

            builder.Property(p => p.GroupName)
            .HasColumnName("group_name")
            .HasComment("Имя группы");
        }
    }
}
