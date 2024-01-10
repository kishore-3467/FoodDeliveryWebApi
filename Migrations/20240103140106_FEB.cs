using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryAppWA.Migrations
{
    /// <inheritdoc />
    public partial class FEB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book_Details",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookGenre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bookPublisher = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Details", x => x.bookId);
                });

            migrationBuilder.CreateTable(
                name: "Cart_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    foodId = table.Column<int>(type: "int", nullable: false),
                    foodQuantity = table.Column<int>(type: "int", nullable: false),
                    foodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    foodImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    foodPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryManId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    orderQueriesIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderQueriesOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deliveryStatus = table.Column<bool>(type: "bit", nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_Details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Food_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    foodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<float>(type: "real", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cookTime = table.Column<int>(type: "int", nullable: false),
                    offerStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    offerEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    offerPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_Details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    foodId = table.Column<int>(type: "int", nullable: false),
                    foodQuantity = table.Column<int>(type: "int", nullable: false),
                    foodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    foodImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    foodPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deliveryId = table.Column<int>(type: "int", nullable: false),
                    deliveryManId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTable_Details",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    employeeLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTable_Details", x => x.employeeId);
                });

            migrationBuilder.CreateTable(
                name: "User_Details",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userNumber = table.Column<double>(type: "float", nullable: false),
                    userAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userAvailability = table.Column<bool>(type: "bit", nullable: false),
                    deliveryId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Details", x => x.userId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Details");

            migrationBuilder.DropTable(
                name: "Cart_Details");

            migrationBuilder.DropTable(
                name: "Delivery_Details");

            migrationBuilder.DropTable(
                name: "Food_Details");

            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "TaskTable_Details");

            migrationBuilder.DropTable(
                name: "User_Details");
        }
    }
}
