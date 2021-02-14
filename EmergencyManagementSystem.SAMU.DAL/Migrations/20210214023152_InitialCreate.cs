using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmergencyManagementSystem.SAMU.DAL.Migrations
{
    public partial class InitialCreate : Migration
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
                    varchar = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OperationCity = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    VehiclePlate = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false),
                    VehicleName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    VehicleStatus = table.Column<int>(type: "int", nullable: false)
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
                name: "Members",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartedWork = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishedWork = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmployeeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeStatus = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "dbo",
                        principalTable: "Vehicles",
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyRequiredVehicles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false),
                    CodeColor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyRequiredVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyRequiredVehicles_Emergencies_EmergencyId",
                        column: x => x.EmergencyId,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    EmergencyId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceHistoryStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Emergencies_EmergencyId",
                        column: x => x.EmergencyId,
                        principalSchema: "dbo",
                        principalTable: "Emergencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Vehicles_VehicleId",
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
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
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
                        name: "FK_MedicalEvaluations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceHistoryId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "dbo",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_ServiceHistories_ServiceHistoryId",
                        column: x => x.ServiceHistoryId,
                        principalSchema: "dbo",
                        principalTable: "ServiceHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePositionHistories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehiclePosition = table.Column<int>(type: "int", nullable: false),
                    ServiceHistoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePositionHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePositionHistories_ServiceHistories_ServiceHistoryId",
                        column: x => x.ServiceHistoryId,
                        principalSchema: "dbo",
                        principalTable: "ServiceHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_AddressId",
                schema: "dbo",
                table: "Emergencies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyHistories_EmergencyId",
                schema: "dbo",
                table: "EmergencyHistories",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyRequiredVehicles_EmergencyId",
                schema: "dbo",
                table: "EmergencyRequiredVehicles",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEvaluations_EmergencyId",
                schema: "dbo",
                table: "MedicalEvaluations",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEvaluations_PatientId",
                schema: "dbo",
                table: "MedicalEvaluations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_VehicleId",
                schema: "dbo",
                table: "Members",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EmergencyId",
                schema: "dbo",
                table: "Patients",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_EmergencyId",
                schema: "dbo",
                table: "ServiceHistories",
                column: "EmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_VehicleId",
                schema: "dbo",
                table: "ServiceHistories",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_MemberId",
                schema: "dbo",
                table: "TeamMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_ServiceHistoryId",
                schema: "dbo",
                table: "TeamMembers",
                column: "ServiceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePositionHistories_ServiceHistoryId",
                schema: "dbo",
                table: "VehiclePositionHistories",
                column: "ServiceHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmergencyHistories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmergencyRequiredVehicles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalEvaluations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TeamMembers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VehiclePositionHistories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ServiceHistories",
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
