using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AT.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacotesTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacotesTuristicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacoteTuristicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                        column: x => x.PacoteTuristicoId,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    PacoteTuristicoId = table.Column<int>(type: "int", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                        column: x => x.PacoteTuristicoId,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "Id", "Nome", "PacoteTuristicoId", "Pais" },
                values: new object[,]
                {
                    { 1, "Coliseu", null, "Itália" },
                    { 2, "Acrópole", null, "Grécia" },
                    { 3, "Torre Eiffel", null, "França" },
                    { 4, "Machu Picchu", null, "Peru" },
                    { 5, "Grand Canyon", null, "Estados Unidos" }
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "Id", "Cidade", "Rua" },
                values: new object[,]
                {
                    { 1, "São Paulo", "Rua das Palmeiras, 123" },
                    { 2, "Rio de Janeiro", "Avenida Brasil, 456" },
                    { 3, "Curitiba", "Rua XV de Novembro, 789" },
                    { 4, "Porto Alegre", "Rua Sete de Setembro, 101" },
                    { 5, "Belo Horizonte", "Avenida Afonso Pena, 202" }
                });

            migrationBuilder.InsertData(
                table: "PacotesTuristicos",
                columns: new[] { "Id", "CapacidadeMaxima", "DataInicio", "Preco", "Titulo" },
                values: new object[,]
                {
                    { 1, 25, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.50m, "Descubra Roma" },
                    { 2, 20, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500.00m, "Encantos da Grécia" },
                    { 3, 30, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1800.75m, "Paris Romântica" },
                    { 4, 15, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200.99m, "Aventura nos Andes" },
                    { 5, 18, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000.00m, "Explorando o Oeste Americano" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Email", "EnderecoId", "Nome" },
                values: new object[,]
                {
                    { 1, "alice.fernandes@email.com", 1, "Alice Fernandes" },
                    { 2, "bruno.martins@email.com", 2, "Bruno Martins" },
                    { 3, "carla.ribeiro@email.com", 3, "Carla Ribeiro" },
                    { 4, "diego.souza@email.com", 4, "Diego Souza" },
                    { 5, "elaine.costa@email.com", 5, "Elaine Costa" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "ClienteId", "DataReserva", "PacoteTuristicoId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 2, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, 5, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PacoteTuristicoId",
                table: "Reservas",
                column: "PacoteTuristicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PacotesTuristicos");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
