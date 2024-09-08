using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P7CreateRestApi.Migrations
{
    public partial class UpdateEntitiesAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bids",
                table: "Bids");

            migrationBuilder.RenameTable(
                name: "Bids",
                newName: "BidLists");

            migrationBuilder.RenameColumn(
                name: "TradeStatus",
                table: "Trades",
                newName: "Trade_Status");

            migrationBuilder.RenameColumn(
                name: "TradeSecurity",
                table: "Trades",
                newName: "Trade_Security");

            migrationBuilder.RenameColumn(
                name: "TradeDate",
                table: "Trades",
                newName: "Trade_Date");

            migrationBuilder.RenameColumn(
                name: "SourceListId",
                table: "Trades",
                newName: "Source_List_Id");

            migrationBuilder.RenameColumn(
                name: "SellQuantity",
                table: "Trades",
                newName: "Sell_Quantity");

            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "Trades",
                newName: "Sell_Price");

            migrationBuilder.RenameColumn(
                name: "RevisionName",
                table: "Trades",
                newName: "Revision_Name");

            migrationBuilder.RenameColumn(
                name: "RevisionDate",
                table: "Trades",
                newName: "Revision_Date");

            migrationBuilder.RenameColumn(
                name: "DealType",
                table: "Trades",
                newName: "Deal_Type");

            migrationBuilder.RenameColumn(
                name: "DealName",
                table: "Trades",
                newName: "Deal_Name");

            migrationBuilder.RenameColumn(
                name: "CreationName",
                table: "Trades",
                newName: "Creation_Name");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Trades",
                newName: "Creation_Date");

            migrationBuilder.RenameColumn(
                name: "BuyQuantity",
                table: "Trades",
                newName: "Buy_Quantity");

            migrationBuilder.RenameColumn(
                name: "BuyPrice",
                table: "Trades",
                newName: "Buy_Price");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Trades",
                newName: "Account_Type");

            migrationBuilder.RenameColumn(
                name: "TradeId",
                table: "Trades",
                newName: "Trade_Id");

            migrationBuilder.RenameColumn(
                name: "SqlStr",
                table: "RuleNames",
                newName: "Sql_Str");

            migrationBuilder.RenameColumn(
                name: "SqlPart",
                table: "RuleNames",
                newName: "Sql_Part");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RuleNames",
                newName: "RuleName_Id");

            migrationBuilder.RenameColumn(
                name: "SandPRating",
                table: "Ratings",
                newName: "SAndP_Rating");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "Ratings",
                newName: "Order_Number");

            migrationBuilder.RenameColumn(
                name: "MoodysRating",
                table: "Ratings",
                newName: "Moodys_Rating");

            migrationBuilder.RenameColumn(
                name: "FitchRating",
                table: "Ratings",
                newName: "Fitch_Rating");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ratings",
                newName: "Rating_Id");

            migrationBuilder.RenameColumn(
                name: "CurvePointValue",
                table: "CurvePoints",
                newName: "CurvePoint_Value");

            migrationBuilder.RenameColumn(
                name: "CurveId",
                table: "CurvePoints",
                newName: "Curve_Id");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "CurvePoints",
                newName: "Creation_Date");

            migrationBuilder.RenameColumn(
                name: "AsOfDate",
                table: "CurvePoints",
                newName: "As_Of_Date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CurvePoints",
                newName: "CurvePoint_Id");

            migrationBuilder.RenameColumn(
                name: "Trader",
                table: "BidLists",
                newName: "Trader_Name");

            migrationBuilder.RenameColumn(
                name: "SourceListId",
                table: "BidLists",
                newName: "Source_List_Id");

            migrationBuilder.RenameColumn(
                name: "RevisionName",
                table: "BidLists",
                newName: "Revision_Name");

            migrationBuilder.RenameColumn(
                name: "RevisionDate",
                table: "BidLists",
                newName: "Revision_Date");

            migrationBuilder.RenameColumn(
                name: "DealType",
                table: "BidLists",
                newName: "Deal_Type");

            migrationBuilder.RenameColumn(
                name: "DealName",
                table: "BidLists",
                newName: "Deal_Name");

            migrationBuilder.RenameColumn(
                name: "CreationName",
                table: "BidLists",
                newName: "Creation_Name");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "BidLists",
                newName: "Creation_Date");

            migrationBuilder.RenameColumn(
                name: "BidType",
                table: "BidLists",
                newName: "Bid_Type");

            migrationBuilder.RenameColumn(
                name: "BidStatus",
                table: "BidLists",
                newName: "Bid_Status");

            migrationBuilder.RenameColumn(
                name: "BidSecurity",
                table: "BidLists",
                newName: "Bid_Security");

            migrationBuilder.RenameColumn(
                name: "BidQuantity",
                table: "BidLists",
                newName: "Bid_Quantity");

            migrationBuilder.RenameColumn(
                name: "BidListDate",
                table: "BidLists",
                newName: "BidList_Date");

            migrationBuilder.RenameColumn(
                name: "AskQuantity",
                table: "BidLists",
                newName: "Ask_Quantity");

            migrationBuilder.RenameColumn(
                name: "BidListId",
                table: "BidLists",
                newName: "BidList_Id");

            migrationBuilder.AddColumn<int>(
                name: "BidList_Id",
                table: "Trades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating_Id",
                table: "Trades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "Trades",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RuleNames",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RuleNames",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SAndP_Rating",
                table: "Ratings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Moodys_Rating",
                table: "Ratings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fitch_Rating",
                table: "Ratings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Rating_Id",
                table: "BidLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidLists",
                table: "BidLists",
                column: "BidList_Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_BidLists_Rating_Id",
                table: "BidLists",
                column: "Rating_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BidLists_Ratings_Rating_Id",
                table: "BidLists",
                column: "Rating_Id",
                principalTable: "Ratings",
                principalColumn: "Rating_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_AspNetUsers_User_Id",
                table: "Trades",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_BidLists_BidList_Id",
                table: "Trades",
                column: "BidList_Id",
                principalTable: "BidLists",
                principalColumn: "BidList_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Ratings_Rating_Id",
                table: "Trades",
                column: "Rating_Id",
                principalTable: "Ratings",
                principalColumn: "Rating_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidLists_Ratings_Rating_Id",
                table: "BidLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_AspNetUsers_User_Id",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_BidLists_BidList_Id",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Ratings_Rating_Id",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_BidList_Id",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_Rating_Id",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_User_Id",
                table: "Trades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidLists",
                table: "BidLists");

            migrationBuilder.DropIndex(
                name: "IX_BidLists_Rating_Id",
                table: "BidLists");

            migrationBuilder.DropColumn(
                name: "BidList_Id",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "Rating_Id",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "Rating_Id",
                table: "BidLists");

            migrationBuilder.RenameTable(
                name: "BidLists",
                newName: "Bids");

            migrationBuilder.RenameColumn(
                name: "Trade_Status",
                table: "Trades",
                newName: "TradeStatus");

            migrationBuilder.RenameColumn(
                name: "Trade_Security",
                table: "Trades",
                newName: "TradeSecurity");

            migrationBuilder.RenameColumn(
                name: "Trade_Date",
                table: "Trades",
                newName: "TradeDate");

            migrationBuilder.RenameColumn(
                name: "Source_List_Id",
                table: "Trades",
                newName: "SourceListId");

            migrationBuilder.RenameColumn(
                name: "Sell_Quantity",
                table: "Trades",
                newName: "SellQuantity");

            migrationBuilder.RenameColumn(
                name: "Sell_Price",
                table: "Trades",
                newName: "SellPrice");

            migrationBuilder.RenameColumn(
                name: "Revision_Name",
                table: "Trades",
                newName: "RevisionName");

            migrationBuilder.RenameColumn(
                name: "Revision_Date",
                table: "Trades",
                newName: "RevisionDate");

            migrationBuilder.RenameColumn(
                name: "Deal_Type",
                table: "Trades",
                newName: "DealType");

            migrationBuilder.RenameColumn(
                name: "Deal_Name",
                table: "Trades",
                newName: "DealName");

            migrationBuilder.RenameColumn(
                name: "Creation_Name",
                table: "Trades",
                newName: "CreationName");

            migrationBuilder.RenameColumn(
                name: "Creation_Date",
                table: "Trades",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Buy_Quantity",
                table: "Trades",
                newName: "BuyQuantity");

            migrationBuilder.RenameColumn(
                name: "Buy_Price",
                table: "Trades",
                newName: "BuyPrice");

            migrationBuilder.RenameColumn(
                name: "Account_Type",
                table: "Trades",
                newName: "AccountType");

            migrationBuilder.RenameColumn(
                name: "Trade_Id",
                table: "Trades",
                newName: "TradeId");

            migrationBuilder.RenameColumn(
                name: "Sql_Str",
                table: "RuleNames",
                newName: "SqlStr");

            migrationBuilder.RenameColumn(
                name: "Sql_Part",
                table: "RuleNames",
                newName: "SqlPart");

            migrationBuilder.RenameColumn(
                name: "RuleName_Id",
                table: "RuleNames",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SAndP_Rating",
                table: "Ratings",
                newName: "SandPRating");

            migrationBuilder.RenameColumn(
                name: "Order_Number",
                table: "Ratings",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "Moodys_Rating",
                table: "Ratings",
                newName: "MoodysRating");

            migrationBuilder.RenameColumn(
                name: "Fitch_Rating",
                table: "Ratings",
                newName: "FitchRating");

            migrationBuilder.RenameColumn(
                name: "Rating_Id",
                table: "Ratings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Curve_Id",
                table: "CurvePoints",
                newName: "CurveId");

            migrationBuilder.RenameColumn(
                name: "CurvePoint_Value",
                table: "CurvePoints",
                newName: "CurvePointValue");

            migrationBuilder.RenameColumn(
                name: "Creation_Date",
                table: "CurvePoints",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "As_Of_Date",
                table: "CurvePoints",
                newName: "AsOfDate");

            migrationBuilder.RenameColumn(
                name: "CurvePoint_Id",
                table: "CurvePoints",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Trader_Name",
                table: "Bids",
                newName: "Trader");

            migrationBuilder.RenameColumn(
                name: "Source_List_Id",
                table: "Bids",
                newName: "SourceListId");

            migrationBuilder.RenameColumn(
                name: "Revision_Name",
                table: "Bids",
                newName: "RevisionName");

            migrationBuilder.RenameColumn(
                name: "Revision_Date",
                table: "Bids",
                newName: "RevisionDate");

            migrationBuilder.RenameColumn(
                name: "Deal_Type",
                table: "Bids",
                newName: "DealType");

            migrationBuilder.RenameColumn(
                name: "Deal_Name",
                table: "Bids",
                newName: "DealName");

            migrationBuilder.RenameColumn(
                name: "Creation_Name",
                table: "Bids",
                newName: "CreationName");

            migrationBuilder.RenameColumn(
                name: "Creation_Date",
                table: "Bids",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Bid_Type",
                table: "Bids",
                newName: "BidType");

            migrationBuilder.RenameColumn(
                name: "Bid_Status",
                table: "Bids",
                newName: "BidStatus");

            migrationBuilder.RenameColumn(
                name: "Bid_Security",
                table: "Bids",
                newName: "BidSecurity");

            migrationBuilder.RenameColumn(
                name: "Bid_Quantity",
                table: "Bids",
                newName: "BidQuantity");

            migrationBuilder.RenameColumn(
                name: "BidList_Date",
                table: "Bids",
                newName: "BidListDate");

            migrationBuilder.RenameColumn(
                name: "Ask_Quantity",
                table: "Bids",
                newName: "AskQuantity");

            migrationBuilder.RenameColumn(
                name: "BidList_Id",
                table: "Bids",
                newName: "BidListId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RuleNames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RuleNames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SandPRating",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "MoodysRating",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FitchRating",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bids",
                table: "Bids",
                column: "BidListId");
        }
    }
}
