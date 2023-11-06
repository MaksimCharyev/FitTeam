using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FitTeamAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentDescription = table.Column<string>(type: "text", nullable: false),
                    CommentType = table.Column<int>(type: "integer", nullable: false),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.CommentID);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseName = table.Column<string>(type: "text", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JsonCourse = table.Column<JsonDocument>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentName = table.Column<string>(type: "text", nullable: false),
                    DocumentPath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.DocumentID);
                });

            migrationBuilder.CreateTable(
                name: "norms",
                columns: table => new
                {
                    NormID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NormName = table.Column<string>(type: "text", nullable: false),
                    NormDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_norms", x => x.NormID);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PermissionName = table.Column<string>(type: "text", nullable: false),
                    PermissionDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionDescription = table.Column<string>(type: "text", nullable: false),
                    QuestionType = table.Column<int>(type: "integer", nullable: false),
                    Answers = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    RoleDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "salePlans",
                columns: table => new
                {
                    SalePlanID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalePlanName = table.Column<string>(type: "text", nullable: false),
                    URL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salePlans", x => x.SalePlanID);
                });

            migrationBuilder.CreateTable(
                name: "subdivisions",
                columns: table => new
                {
                    SubdivisionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubdivisionName = table.Column<string>(type: "text", nullable: false),
                    SubdivisionDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivisions", x => x.SubdivisionID);
                });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestName = table.Column<string>(type: "text", nullable: false),
                    TestDescription = table.Column<string>(type: "text", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isCertification = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.TestID);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    UUID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "roles_has_courses",
                columns: table => new
                {
                    RCoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    CourseID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_has_courses", x => x.RCoID);
                    table.ForeignKey(
                        name: "FK_roles_has_courses_courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_has_courses_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles_has_docs",
                columns: table => new
                {
                    RDID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    DocumentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_has_docs", x => x.RDID);
                    table.ForeignKey(
                        name: "FK_roles_has_docs_documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "documents",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_has_docs_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles_has_norms",
                columns: table => new
                {
                    RNID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    NormID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_has_norms", x => x.RNID);
                    table.ForeignKey(
                        name: "FK_roles_has_norms_norms_NormID",
                        column: x => x.NormID,
                        principalTable: "norms",
                        principalColumn: "NormID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_has_norms_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles_has_perms",
                columns: table => new
                {
                    RPID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    PermissionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_has_perms", x => x.RPID);
                    table.ForeignKey(
                        name: "FK_roles_has_perms_permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "permissions",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_has_perms_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subdivisions_has_courses",
                columns: table => new
                {
                    SCoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubdivisionID = table.Column<int>(type: "integer", nullable: false),
                    CourseID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivisions_has_courses", x => x.SCoID);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_courses_courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_courses_subdivisions_SubdivisionID",
                        column: x => x.SubdivisionID,
                        principalTable: "subdivisions",
                        principalColumn: "SubdivisionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subdivisions_has_docs",
                columns: table => new
                {
                    SDID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubdivisionID = table.Column<int>(type: "integer", nullable: false),
                    DocumentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivisions_has_docs", x => x.SDID);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_docs_documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "documents",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_docs_subdivisions_SubdivisionID",
                        column: x => x.SubdivisionID,
                        principalTable: "subdivisions",
                        principalColumn: "SubdivisionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subdivisions_has_norms",
                columns: table => new
                {
                    SNID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubdivisionID = table.Column<int>(type: "integer", nullable: true),
                    SubdivisonID = table.Column<int>(type: "integer", nullable: false),
                    NormID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivisions_has_norms", x => x.SNID);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_norms_norms_NormID",
                        column: x => x.NormID,
                        principalTable: "norms",
                        principalColumn: "NormID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_norms_subdivisions_SubdivisionID",
                        column: x => x.SubdivisionID,
                        principalTable: "subdivisions",
                        principalColumn: "SubdivisionID");
                });

            migrationBuilder.CreateTable(
                name: "subdivisions_has_plans",
                columns: table => new
                {
                    SPID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubdivisionID = table.Column<int>(type: "integer", nullable: false),
                    SalePlanID = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false),
                    IsOld = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivisions_has_plans", x => x.SPID);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_plans_salePlans_SalePlanID",
                        column: x => x.SalePlanID,
                        principalTable: "salePlans",
                        principalColumn: "SalePlanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_plans_subdivisions_SubdivisionID",
                        column: x => x.SubdivisionID,
                        principalTable: "subdivisions",
                        principalColumn: "SubdivisionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles_has_tests",
                columns: table => new
                {
                    RTID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    TestID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_has_tests", x => x.RTID);
                    table.ForeignKey(
                        name: "FK_roles_has_tests_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_has_tests_tests_TestID",
                        column: x => x.TestID,
                        principalTable: "tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subdivisions_has_tests",
                columns: table => new
                {
                    STID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubdivisionID = table.Column<int>(type: "integer", nullable: false),
                    TestID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivisions_has_tests", x => x.STID);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_tests_subdivisions_SubdivisionID",
                        column: x => x.SubdivisionID,
                        principalTable: "subdivisions",
                        principalColumn: "SubdivisionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subdivisions_has_tests_tests_TestID",
                        column: x => x.TestID,
                        principalTable: "tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tests_has_questions",
                columns: table => new
                {
                    TQID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestID = table.Column<int>(type: "integer", nullable: false),
                    QuestionID = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests_has_questions", x => x.TQID);
                    table.ForeignKey(
                        name: "FK_tests_has_questions_questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tests_has_questions_tests_TestID",
                        column: x => x.TestID,
                        principalTable: "tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventName = table.Column<string>(type: "text", nullable: false),
                    EventDescription = table.Column<string>(type: "text", nullable: false),
                    EventTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HostUUID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_events_workers_HostUUID",
                        column: x => x.HostUUID,
                        principalTable: "workers",
                        principalColumn: "UUID");
                });

            migrationBuilder.CreateTable(
                name: "workers_courses",
                columns: table => new
                {
                    WCoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerID = table.Column<int>(type: "integer", nullable: false),
                    CourseID = table.Column<int>(type: "integer", nullable: false),
                    DoneTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Mark = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers_courses", x => x.WCoID);
                    table.ForeignKey(
                        name: "FK_workers_courses_courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_courses_workers_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "workers",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workers_did_tests",
                columns: table => new
                {
                    WTID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerID = table.Column<int>(type: "integer", nullable: false),
                    TestID = table.Column<int>(type: "integer", nullable: false),
                    Begin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Mark = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers_did_tests", x => x.WTID);
                    table.ForeignKey(
                        name: "FK_workers_did_tests_tests_TestID",
                        column: x => x.TestID,
                        principalTable: "tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_did_tests_workers_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "workers",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workers_does_norms",
                columns: table => new
                {
                    WNID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerID = table.Column<int>(type: "integer", nullable: false),
                    NormID = table.Column<int>(type: "integer", nullable: false),
                    NormTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Mark = table.Column<string>(type: "text", nullable: false),
                    HostID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers_does_norms", x => x.WNID);
                    table.ForeignKey(
                        name: "FK_workers_does_norms_norms_NormID",
                        column: x => x.NormID,
                        principalTable: "norms",
                        principalColumn: "NormID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_does_norms_workers_HostID",
                        column: x => x.HostID,
                        principalTable: "workers",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_does_norms_workers_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "workers",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workers_has_comments",
                columns: table => new
                {
                    WCID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToID = table.Column<int>(type: "integer", nullable: false),
                    CommentID = table.Column<int>(type: "integer", nullable: false),
                    FromID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers_has_comments", x => x.WCID);
                    table.ForeignKey(
                        name: "FK_workers_has_comments_comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_has_comments_workers_FromID",
                        column: x => x.FromID,
                        principalTable: "workers",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_has_comments_workers_ToID",
                        column: x => x.ToID,
                        principalTable: "workers",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workers_has_Roles",
                columns: table => new
                {
                    WRID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerUUID = table.Column<int>(type: "integer", nullable: true),
                    RoleID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers_has_Roles", x => x.WRID);
                    table.ForeignKey(
                        name: "FK_workers_has_Roles_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID");
                    table.ForeignKey(
                        name: "FK_workers_has_Roles_workers_WorkerUUID",
                        column: x => x.WorkerUUID,
                        principalTable: "workers",
                        principalColumn: "UUID");
                });

            migrationBuilder.CreateTable(
                name: "workers_know_docs",
                columns: table => new
                {
                    WDID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KnowledgeTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkerID = table.Column<int>(type: "integer", nullable: false),
                    DocumentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers_know_docs", x => x.WDID);
                    table.ForeignKey(
                        name: "FK_workers_know_docs_documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "documents",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_know_docs_workers_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "workers",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles_on_events",
                columns: table => new
                {
                    REID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_on_events", x => x.REID);
                    table.ForeignKey(
                        name: "FK_roles_on_events_events_EventID",
                        column: x => x.EventID,
                        principalTable: "events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_on_events_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subdivisions_on_events",
                columns: table => new
                {
                    SEID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubdivisionID = table.Column<int>(type: "integer", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivisions_on_events", x => x.SEID);
                    table.ForeignKey(
                        name: "FK_subdivisions_on_events_events_EventID",
                        column: x => x.EventID,
                        principalTable: "events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subdivisions_on_events_subdivisions_SubdivisionID",
                        column: x => x.SubdivisionID,
                        principalTable: "subdivisions",
                        principalColumn: "SubdivisionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workers_on_events",
                columns: table => new
                {
                    WEID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerID = table.Column<int>(type: "integer", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers_on_events", x => x.WEID);
                    table.ForeignKey(
                        name: "FK_workers_on_events_events_EventID",
                        column: x => x.EventID,
                        principalTable: "events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_on_events_workers_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "workers",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_HostUUID",
                table: "events",
                column: "HostUUID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_courses_CourseID",
                table: "roles_has_courses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_courses_RoleID",
                table: "roles_has_courses",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_docs_DocumentID",
                table: "roles_has_docs",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_docs_RoleID",
                table: "roles_has_docs",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_norms_NormID",
                table: "roles_has_norms",
                column: "NormID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_norms_RoleID",
                table: "roles_has_norms",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_perms_PermissionID",
                table: "roles_has_perms",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_perms_RoleID",
                table: "roles_has_perms",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_tests_RoleID",
                table: "roles_has_tests",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_has_tests_TestID",
                table: "roles_has_tests",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_on_events_EventID",
                table: "roles_on_events",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_on_events_RoleID",
                table: "roles_on_events",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_courses_CourseID",
                table: "subdivisions_has_courses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_courses_SubdivisionID",
                table: "subdivisions_has_courses",
                column: "SubdivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_docs_DocumentID",
                table: "subdivisions_has_docs",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_docs_SubdivisionID",
                table: "subdivisions_has_docs",
                column: "SubdivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_norms_NormID",
                table: "subdivisions_has_norms",
                column: "NormID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_norms_SubdivisionID",
                table: "subdivisions_has_norms",
                column: "SubdivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_plans_SalePlanID",
                table: "subdivisions_has_plans",
                column: "SalePlanID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_plans_SubdivisionID",
                table: "subdivisions_has_plans",
                column: "SubdivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_tests_SubdivisionID",
                table: "subdivisions_has_tests",
                column: "SubdivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_has_tests_TestID",
                table: "subdivisions_has_tests",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_on_events_EventID",
                table: "subdivisions_on_events",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_subdivisions_on_events_SubdivisionID",
                table: "subdivisions_on_events",
                column: "SubdivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_tests_has_questions_QuestionID",
                table: "tests_has_questions",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_tests_has_questions_TestID",
                table: "tests_has_questions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_courses_CourseID",
                table: "workers_courses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_courses_WorkerID",
                table: "workers_courses",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_did_tests_TestID",
                table: "workers_did_tests",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_did_tests_WorkerID",
                table: "workers_did_tests",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_does_norms_HostID",
                table: "workers_does_norms",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_does_norms_NormID",
                table: "workers_does_norms",
                column: "NormID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_does_norms_WorkerID",
                table: "workers_does_norms",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_has_comments_CommentID",
                table: "workers_has_comments",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_has_comments_FromID",
                table: "workers_has_comments",
                column: "FromID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_has_comments_ToID",
                table: "workers_has_comments",
                column: "ToID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_has_Roles_RoleID",
                table: "workers_has_Roles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_has_Roles_WorkerUUID",
                table: "workers_has_Roles",
                column: "WorkerUUID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_know_docs_DocumentID",
                table: "workers_know_docs",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_know_docs_WorkerID",
                table: "workers_know_docs",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_on_events_EventID",
                table: "workers_on_events",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_workers_on_events_WorkerID",
                table: "workers_on_events",
                column: "WorkerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roles_has_courses");

            migrationBuilder.DropTable(
                name: "roles_has_docs");

            migrationBuilder.DropTable(
                name: "roles_has_norms");

            migrationBuilder.DropTable(
                name: "roles_has_perms");

            migrationBuilder.DropTable(
                name: "roles_has_tests");

            migrationBuilder.DropTable(
                name: "roles_on_events");

            migrationBuilder.DropTable(
                name: "subdivisions_has_courses");

            migrationBuilder.DropTable(
                name: "subdivisions_has_docs");

            migrationBuilder.DropTable(
                name: "subdivisions_has_norms");

            migrationBuilder.DropTable(
                name: "subdivisions_has_plans");

            migrationBuilder.DropTable(
                name: "subdivisions_has_tests");

            migrationBuilder.DropTable(
                name: "subdivisions_on_events");

            migrationBuilder.DropTable(
                name: "tests_has_questions");

            migrationBuilder.DropTable(
                name: "workers_courses");

            migrationBuilder.DropTable(
                name: "workers_did_tests");

            migrationBuilder.DropTable(
                name: "workers_does_norms");

            migrationBuilder.DropTable(
                name: "workers_has_comments");

            migrationBuilder.DropTable(
                name: "workers_has_Roles");

            migrationBuilder.DropTable(
                name: "workers_know_docs");

            migrationBuilder.DropTable(
                name: "workers_on_events");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "salePlans");

            migrationBuilder.DropTable(
                name: "subdivisions");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "norms");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "workers");
        }
    }
}
