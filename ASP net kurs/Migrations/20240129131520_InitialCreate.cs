using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_net_kurs.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posetitel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Фамилия = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Имя = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Отчество = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Возраст = table.Column<int>(type: "int", nullable: false),
                    Размер_багажа = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Судимость = table.Column<bool>(type: "bit", nullable: false),
                    Комната = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Питомец = table.Column<bool>(type: "bit", nullable: false),
                    Мини_бар = table.Column<bool>(type: "bit", nullable: false),
                    Фото = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posetitel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rabotnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Фамилия = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Имя = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Отчество = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Рост = table.Column<int>(type: "int", nullable: false),
                    Должность = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Стаж = table.Column<int>(type: "int", nullable: false),
                    Планета_происхождения = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Образование = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Возраст = table.Column<int>(type: "int", nullable: false),
                    Фото = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rabotnik", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posetitel");

            migrationBuilder.DropTable(
                name: "Rabotnik");
        }
    }
}
