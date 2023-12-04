using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TransOilApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TransOilApi");

            migrationBuilder.CreateTable(
                name: "CurrentTransformers",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CheckingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    KTT = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricEnergyMeters",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CheckingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricEnergyMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricitySupplyPoints",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxPower = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricitySupplyPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoltageTransformers",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CheckingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    KTN = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoltageTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildOrganizations",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    OrganisationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildOrganizations_Organizations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalSchema: "TransOilApi",
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionObjects",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ChildOrganizationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumptionObjects_ChildOrganizations_ChildOrganizationId",
                        column: x => x.ChildOrganizationId,
                        principalSchema: "TransOilApi",
                        principalTable: "ChildOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeasurementPoints",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ConsumptionObjectId = table.Column<long>(type: "bigint", nullable: true),
                    CurrentTransformerId = table.Column<long>(type: "bigint", nullable: false),
                    VoltageTransformerId = table.Column<long>(type: "bigint", nullable: false),
                    ElectricEnergyMeterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeasurementPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasurementPoints_ConsumptionObjects_Consumption~",
                        column: x => x.ConsumptionObjectId,
                        principalSchema: "TransOilApi",
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectricityMeasurementPoints_CurrentTransformers_CurrentTra~",
                        column: x => x.CurrentTransformerId,
                        principalSchema: "TransOilApi",
                        principalTable: "CurrentTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasurementPoints_ElectricEnergyMeters_ElectricE~",
                        column: x => x.ElectricEnergyMeterId,
                        principalSchema: "TransOilApi",
                        principalTable: "ElectricEnergyMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasurementPoints_VoltageTransformers_VoltageTra~",
                        column: x => x.VoltageTransformerId,
                        principalSchema: "TransOilApi",
                        principalTable: "VoltageTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculationMeters",
                schema: "TransOilApi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ElectricityMeasurementPointId = table.Column<long>(type: "bigint", nullable: false),
                    ElectricitySupplyPointId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationMeters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationMeters_ElectricityMeasurementPoints_ElectricityM~",
                        column: x => x.ElectricityMeasurementPointId,
                        principalSchema: "TransOilApi",
                        principalTable: "ElectricityMeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalculationMeters_ElectricitySupplyPoints_ElectricitySupply~",
                        column: x => x.ElectricitySupplyPointId,
                        principalSchema: "TransOilApi",
                        principalTable: "ElectricitySupplyPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculationMeters_ElectricityMeasurementPointId_Electricity~",
                schema: "TransOilApi",
                table: "CalculationMeters",
                columns: new[] { "ElectricityMeasurementPointId", "ElectricitySupplyPointId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalculationMeters_ElectricitySupplyPointId",
                schema: "TransOilApi",
                table: "CalculationMeters",
                column: "ElectricitySupplyPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildOrganizations_Name_Address",
                schema: "TransOilApi",
                table: "ChildOrganizations",
                columns: new[] { "Name", "Address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChildOrganizations_OrganisationId",
                schema: "TransOilApi",
                table: "ChildOrganizations",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionObjects_ChildOrganizationId",
                schema: "TransOilApi",
                table: "ConsumptionObjects",
                column: "ChildOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionObjects_ObjectName_Address",
                schema: "TransOilApi",
                table: "ConsumptionObjects",
                columns: new[] { "ObjectName", "Address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTransformers_Number",
                schema: "TransOilApi",
                table: "CurrentTransformers",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricEnergyMeters_Number",
                schema: "TransOilApi",
                table: "ElectricEnergyMeters",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasurementPoints_ConsumptionObjectId",
                schema: "TransOilApi",
                table: "ElectricityMeasurementPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasurementPoints_CurrentTransformerId",
                schema: "TransOilApi",
                table: "ElectricityMeasurementPoints",
                column: "CurrentTransformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasurementPoints_ElectricEnergyMeterId",
                schema: "TransOilApi",
                table: "ElectricityMeasurementPoints",
                column: "ElectricEnergyMeterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasurementPoints_Name",
                schema: "TransOilApi",
                table: "ElectricityMeasurementPoints",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasurementPoints_VoltageTransformerId",
                schema: "TransOilApi",
                table: "ElectricityMeasurementPoints",
                column: "VoltageTransformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricitySupplyPoints_Name",
                schema: "TransOilApi",
                table: "ElectricitySupplyPoints",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Name_Address",
                schema: "TransOilApi",
                table: "Organizations",
                columns: new[] { "Name", "Address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoltageTransformers_Number",
                schema: "TransOilApi",
                table: "VoltageTransformers",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationMeters",
                schema: "TransOilApi");

            migrationBuilder.DropTable(
                name: "ElectricityMeasurementPoints",
                schema: "TransOilApi");

            migrationBuilder.DropTable(
                name: "ElectricitySupplyPoints",
                schema: "TransOilApi");

            migrationBuilder.DropTable(
                name: "ConsumptionObjects",
                schema: "TransOilApi");

            migrationBuilder.DropTable(
                name: "CurrentTransformers",
                schema: "TransOilApi");

            migrationBuilder.DropTable(
                name: "ElectricEnergyMeters",
                schema: "TransOilApi");

            migrationBuilder.DropTable(
                name: "VoltageTransformers",
                schema: "TransOilApi");

            migrationBuilder.DropTable(
                name: "ChildOrganizations",
                schema: "TransOilApi");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "TransOilApi");
        }
    }
}
