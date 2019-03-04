using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Submitter",
                columns: table => new
                {
                    applicantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(nullable: false),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    midInitial = table.Column<string>(maxLength: 1, nullable: true),
                    state = table.Column<string>(maxLength: 2, nullable: false),
                    submitterEmail = table.Column<string>(nullable: true),
                    submitterPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submitter", x => x.applicantID);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    educationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: false),
                    educationlevelId = table.Column<int>(nullable: false),
                    enddate = table.Column<DateTime>(nullable: false),
                    fieldofStudy = table.Column<string>(nullable: true),
                    schoolCity = table.Column<string>(nullable: true),
                    schoolName = table.Column<string>(nullable: true),
                    schoolState = table.Column<string>(maxLength: 2, nullable: false),
                    startdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.educationID);
                    table.ForeignKey(
                        name: "FK_Education_Submitter_applicantID",
                        column: x => x.applicantID,
                        principalTable: "Submitter",
                        principalColumn: "applicantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfSummary",
                columns: table => new
                {
                    profSummaryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfSum = table.Column<string>(nullable: true),
                    applicantID = table.Column<int>(nullable: false),
                    sortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfSummary", x => x.profSummaryID);
                    table.ForeignKey(
                        name: "FK_ProfSummary_Submitter_applicantID",
                        column: x => x.applicantID,
                        principalTable: "Submitter",
                        principalColumn: "applicantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    referenceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: false),
                    firstMet = table.Column<DateTime>(nullable: false),
                    referenceEmail = table.Column<string>(nullable: true),
                    referenceName = table.Column<string>(nullable: true),
                    referencePhone = table.Column<string>(nullable: true),
                    relationshipType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.referenceID);
                    table.ForeignKey(
                        name: "FK_Reference_Submitter_applicantID",
                        column: x => x.applicantID,
                        principalTable: "Submitter",
                        principalColumn: "applicantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillSet",
                columns: table => new
                {
                    skillsetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: false),
                    skillSetRecord = table.Column<string>(nullable: true),
                    skillsetType = table.Column<int>(nullable: false),
                    sortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSet", x => x.skillsetID);
                    table.ForeignKey(
                        name: "FK_SkillSet_Submitter_applicantID",
                        column: x => x.applicantID,
                        principalTable: "Submitter",
                        principalColumn: "applicantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    workID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    employer = table.Column<string>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    isStillEmployed = table.Column<bool>(nullable: false),
                    jobTitle = table.Column<string>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    state = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperience", x => x.workID);
                    table.ForeignKey(
                        name: "FK_WorkExperience_Submitter_applicantID",
                        column: x => x.applicantID,
                        principalTable: "Submitter",
                        principalColumn: "applicantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobDescription",
                columns: table => new
                {
                    jobDescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    jobExperience = table.Column<string>(nullable: false),
                    sortOrder = table.Column<int>(nullable: false),
                    workID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescription", x => x.jobDescriptionId);
                    table.ForeignKey(
                        name: "FK_JobDescription_WorkExperience_workID",
                        column: x => x.workID,
                        principalTable: "WorkExperience",
                        principalColumn: "workID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_applicantID",
                table: "Education",
                column: "applicantID");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescription_workID",
                table: "JobDescription",
                column: "workID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfSummary_applicantID",
                table: "ProfSummary",
                column: "applicantID");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_applicantID",
                table: "Reference",
                column: "applicantID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSet_applicantID",
                table: "SkillSet",
                column: "applicantID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_applicantID",
                table: "WorkExperience",
                column: "applicantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "JobDescription");

            migrationBuilder.DropTable(
                name: "ProfSummary");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "SkillSet");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.DropTable(
                name: "Submitter");
        }
    }
}
