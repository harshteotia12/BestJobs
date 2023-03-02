using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class dbpush01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateDetails",
                columns: table => new
                {
                    CandidateDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AddLine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDetails", x => x.CandidateDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "HR",
                columns: table => new
                {
                    HRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HRName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HRYOE = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Orgname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrgPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR", x => x.HRId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SkillProficiency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsId);
                });

            migrationBuilder.CreateTable(
                name: "CandidateResume",
                columns: table => new
                {
                    CandidateResumeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateDetailsId = table.Column<int>(type: "int", nullable: false),
                    TenthSchool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenthSchoolPercentage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TwelfthSchool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TwelfthSchoolPercentage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GraduationSchool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GraduationSchoolPercentage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GraduationStream = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrentOrganization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrentCTC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateResume", x => x.CandidateResumeId);
                    table.ForeignKey(
                        name: "FK_CandidateResume_CandidateDetails_CandidateDetailsId",
                        column: x => x.CandidateDetailsId,
                        principalTable: "CandidateDetails",
                        principalColumn: "CandidateDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CandidateDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Files_CandidateDetails_CandidateDetailsId",
                        column: x => x.CandidateDetailsId,
                        principalTable: "CandidateDetails",
                        principalColumn: "CandidateDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HRId = table.Column<int>(type: "int", nullable: false),
                    JobsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobsSkill = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobsPackage = table.Column<int>(type: "int", nullable: false),
                    JobsPostDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    JobsDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobsId);
                    table.ForeignKey(
                        name: "FK_Jobs_HR_HRId",
                        column: x => x.HRId,
                        principalTable: "HR",
                        principalColumn: "HRId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobStatus",
                columns: table => new
                {
                    JobStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HRUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CandidateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    IsComleted = table.Column<bool>(type: "bit", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatus", x => x.JobStatusId);
                    table.ForeignKey(
                        name: "FK_JobStatus_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "JobsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateResume_CandidateDetailsId",
                table: "CandidateResume",
                column: "CandidateDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CandidateDetailsId",
                table: "Files",
                column: "CandidateDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_HRId",
                table: "Jobs",
                column: "HRId");

            migrationBuilder.CreateIndex(
                name: "IX_JobStatus_JobsId",
                table: "JobStatus",
                column: "JobsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateResume");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "JobStatus");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "CandidateDetails");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "HR");
        }
    }
}
