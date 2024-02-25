using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VlasovaKt.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_name = table.Column<string>(type: "text", nullable: false, comment: "Имя группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_firstname = table.Column<string>(type: "text", nullable: false, comment: "Имя студента"),
                    student_lastname = table.Column<string>(type: "text", nullable: false, comment: "Фамилия студента"),
                    student_middlename = table.Column<string>(type: "text", nullable: false, comment: "Отчество студента"),
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.group_id,
                        principalTable: "Group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_student_fk_f_group_id",
                table: "student",
                column: "group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
