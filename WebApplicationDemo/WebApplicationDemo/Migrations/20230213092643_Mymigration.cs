using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class Mymigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "citasmedicas");

            migrationBuilder.CreateTable(
                name: "DIAGNOSTICO",
                schema: "citasmedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valoracionEspecialista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIAGNOSTICO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                schema: "citasmedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MEDICO",
                schema: "citasmedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    numColegiado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MEDICO_USUARIO_Id",
                        column: x => x.Id,
                        principalSchema: "citasmedicas",
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                schema: "citasmedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NSS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PACIENTE_USUARIO_Id",
                        column: x => x.Id,
                        principalSchema: "citasmedicas",
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendidos",
                schema: "citasmedicas",
                columns: table => new
                {
                    MedicoIdFK = table.Column<int>(type: "int", nullable: false),
                    PacienteIdFK = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendidos", x => new { x.MedicoIdFK, x.PacienteIdFK });
                    table.ForeignKey(
                        name: "FK_Atendidos_MEDICO_MedicoIdFK",
                        column: x => x.MedicoIdFK,
                        principalSchema: "citasmedicas",
                        principalTable: "MEDICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendidos_PACIENTE_PacienteIdFK",
                        column: x => x.PacienteIdFK,
                        principalSchema: "citasmedicas",
                        principalTable: "PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CITA",
                schema: "citasmedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fehcaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    DiagnosticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CITA_DIAGNOSTICO_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalSchema: "citasmedicas",
                        principalTable: "DIAGNOSTICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CITA_MEDICO_MedicoId",
                        column: x => x.MedicoId,
                        principalSchema: "citasmedicas",
                        principalTable: "MEDICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CITA_PACIENTE_PacienteId",
                        column: x => x.PacienteId,
                        principalSchema: "citasmedicas",
                        principalTable: "PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendidos_PacienteIdFK",
                schema: "citasmedicas",
                table: "Atendidos",
                column: "PacienteIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_CITA_DiagnosticoId",
                schema: "citasmedicas",
                table: "CITA",
                column: "DiagnosticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CITA_MedicoId",
                schema: "citasmedicas",
                table: "CITA",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CITA_PacienteId",
                schema: "citasmedicas",
                table: "CITA",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendidos",
                schema: "citasmedicas");

            migrationBuilder.DropTable(
                name: "CITA",
                schema: "citasmedicas");

            migrationBuilder.DropTable(
                name: "DIAGNOSTICO",
                schema: "citasmedicas");

            migrationBuilder.DropTable(
                name: "MEDICO",
                schema: "citasmedicas");

            migrationBuilder.DropTable(
                name: "PACIENTE",
                schema: "citasmedicas");

            migrationBuilder.DropTable(
                name: "USUARIO",
                schema: "citasmedicas");
        }
    }
}
