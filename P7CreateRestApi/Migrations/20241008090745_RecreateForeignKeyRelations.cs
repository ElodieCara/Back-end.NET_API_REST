using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    public partial class RecreateForeignKeyRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurvePoints",
                columns: table => new
                {
                    CurvePoint_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Curve_Id = table.Column<byte>(type: "tinyint", nullable: true),
                    As_Of_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Term = table.Column<double>(type: "float", nullable: true),
                    CurvePoint_Value = table.Column<double>(type: "float", nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurvePoints", x => x.CurvePoint_Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Rating_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moodys_Rating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SAndP_Rating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fitch_Rating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order_Number = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Rating_Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleNames",
                columns: table => new
                {
                    RuleName_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sql_Str = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sql_Part = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleNames", x => x.RuleName_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidLists",
                columns: table => new
                {
                    BidList_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating_Id = table.Column<int>(type: "int", nullable: true),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bid_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bid_Quantity = table.Column<double>(type: "float", nullable: true),
                    Ask_Quantity = table.Column<double>(type: "float", nullable: true),
                    Bid = table.Column<double>(type: "float", nullable: true),
                    Ask = table.Column<double>(type: "float", nullable: true),
                    Benchmark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BidList_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Commentary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bid_Security = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bid_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Trader_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Book = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Creation_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revision_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Revision_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deal_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deal_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Source_List_Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Side = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidLists", x => x.BidList_Id);
                    table.ForeignKey(
                        name: "FK_BidLists_Ratings_Rating_Id",
                        column: x => x.Rating_Id,
                        principalTable: "Ratings",
                        principalColumn: "Rating_Id");
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Trade_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buy_Quantity = table.Column<double>(type: "float", nullable: true),
                    Sell_Quantity = table.Column<double>(type: "float", nullable: true),
                    Buy_Price = table.Column<double>(type: "float", nullable: true),
                    Sell_Price = table.Column<double>(type: "float", nullable: true),
                    Trade_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Trade_Security = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trade_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benchmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Book = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revision_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revision_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deal_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deal_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source_List_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Rating_Id = table.Column<int>(type: "int", nullable: true),
                    BidList_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Trade_Id);
                    table.ForeignKey(
                        name: "FK_Trades_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trades_BidLists_BidList_Id",
                        column: x => x.BidList_Id,
                        principalTable: "BidLists",
                        principalColumn: "BidList_Id");
                    table.ForeignKey(
                        name: "FK_Trades_Ratings_Rating_Id",
                        column: x => x.Rating_Id,
                        principalTable: "Ratings",
                        principalColumn: "Rating_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BidLists_Rating_Id",
                table: "BidLists",
                column: "Rating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_BidList_Id",
                table: "Trades",
                column: "BidList_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_Rating_Id",
                table: "Trades",
                column: "Rating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_User_Id",
                table: "Trades",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CurvePoints");

            migrationBuilder.DropTable(
                name: "RuleNames");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BidLists");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
