using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VlasovaKt.Models;

namespace VlasovaKt.Database.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            builder.Property(p => p.FirstName)
                .HasColumnName("student_firstname")
                .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .HasColumnName("student_lastname")
                .HasComment("Фамилия студента");

            builder.Property(p => p.MiddleName)
                .HasColumnName("student_middlename")
                .HasComment("Отчество студента");

            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи группы");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Group)
                .AutoInclude();

        }
    }
}
