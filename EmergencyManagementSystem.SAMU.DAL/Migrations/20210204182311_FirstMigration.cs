using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmergencyManagementSystem.SAMU.DAL.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    City = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    District = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Street = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Complement = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Reference = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiclePlate = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false),
                    VehicleName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    VehicleSituation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emergencies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    RequesterName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    RequesterPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    EmergencyStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emergencies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyDatas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false),
                    CodeColor = table.Column<int>(type: "int", nullable: false),
                    EmergencyId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyDatas_Emergencies_EmergencyId",
                        column: x => x.EmergencyId,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyDatas_Emergencies_EmergencyId1",
                        column: x => x.EmergencyId1,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyHistories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmergencyStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyHistories_Emergencies_EmergencyId",
                        column: x => x.EmergencyId,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false),
                    EmergencyId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Emergencies_EmergencyId",
                        column: x => x.EmergencyId,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Emergencies_EmergencyId1",
                        column: x => x.EmergencyId1,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTeams",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleTeamStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    EmergencyId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTeams_Emergencies_EmergencyId",
                        column: x => x.EmergencyId,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleTeams_Emergencies_EmergencyId1",
                        column: x => x.EmergencyId1,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleTeams_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "dbo",
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalEvaluations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmployeeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false),
                    Evaluation = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    EmergencyId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalEvaluations_Emergencies_EmergencyId",
                        column: x => x.EmergencyId,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalEvaluations_Emergencies_EmergencyId1",
                        column: x => x.EmergencyId1,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalEvaluations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleTeamId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleTeamId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_VehicleTeams_VehicleTeamId",
                        column: x => x.VehicleTeamId,
                        principalSchema: "dbo",
                        principalTable: "VehicleTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_VehicleTeams_VehicleTeamId1",
                        column: x => x.VehicleTeamId1,
                        principalSchema: "dbo",
                        principalTable: "VehicleTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePositionHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleStatus = table.Column<int>(type: "int", nullable: false),
                    VehicleTeamId1 = table.Column<long>(type: "bigint", nullable: true),
                    VehicleTeamId = table.Column<long>(type: "bigint", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePositionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePositionHistory_Emergencies_EmergencyId",
                        column: x => x.EmergencyId,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePositionHistory_VehicleTeams_VehicleTeamId",
                        column: x => x.VehicleTeamId,
                        principalSchema: "dbo",
                        principalTable: "VehicleTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePositionHistory_VehicleTeams_VehicleTeamId1",
                        column: x => x.VehicleTeamId1,
                        principalSchema: "dbo",
                        principalTable: "VehicleTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_AddressId",
                schema: "dbo",
                table: "Emergencies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyDatas_EmergencyId",
                schema: "dbo",
                table: "EmergencyDatas",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyDatas_EmergencyId1",
                schema: "dbo",
                table: "EmergencyDatas",
                column: "EmergencyId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyHistories_EmergencyId",
                schema: "dbo",
                table: "EmergencyHistories",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEvaluations_EmergencyId",
                schema: "dbo",
                table: "MedicalEvaluations",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEvaluations_EmergencyId1",
                schema: "dbo",
                table: "MedicalEvaluations",
                column: "EmergencyId1");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEvaluations_PatientId",
                schema: "dbo",
                table: "MedicalEvaluations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EmergencyId",
                schema: "dbo",
                table: "Patients",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EmergencyId1",
                schema: "dbo",
                table: "Patients",
                column: "EmergencyId1");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_VehicleTeamId",
                schema: "dbo",
                table: "TeamMembers",
                column: "VehicleTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_VehicleTeamId1",
                schema: "dbo",
                table: "TeamMembers",
                column: "VehicleTeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePositionHistory_EmergencyId",
                table: "VehiclePositionHistory",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePositionHistory_VehicleTeamId",
                table: "VehiclePositionHistory",
                column: "VehicleTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePositionHistory_VehicleTeamId1",
                table: "VehiclePositionHistory",
                column: "VehicleTeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTeams_EmergencyId",
                schema: "dbo",
                table: "VehicleTeams",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTeams_EmergencyId1",
                schema: "dbo",
                table: "VehicleTeams",
                column: "EmergencyId1");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTeams_VehicleId",
                schema: "dbo",
                table: "VehicleTeams",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmergencyDatas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmergencyHistories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalEvaluations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TeamMembers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VehiclePositionHistory");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VehicleTeams",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Emergencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "dbo");
        }
    }
}
