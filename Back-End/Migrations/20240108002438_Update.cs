using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Back_End.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Cuisine = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    PhotosUrl = table.Column<List<string>>(type: "text[]", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Votes = table.Column<int>(type: "integer", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "City", "CreateAt", "Cuisine", "Description", "Latitude", "Longitude", "Name", "PhotosUrl", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1, "2nd Floor, Adityam Building, Ulubari, Guwahati", "Guwahati", new DateTimeOffset(new DateTime(2023, 9, 11, 21, 12, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "North Indian", "Barbeque Nation is a restaurant that goes above and beyond the unlimited food experience. The brand strives to deliver a great customer experience. So the reinvented BBQ Nation is another step in that direction.", 26.168939999999999, 91.763351, "Barbeque Nation", new List<string> { "https://www.businessinsider.in/photo/81662629/barbeque-nation-ipo-issues-opens-today-should-you-subscribe.jpg" }, 1, 0 },
                    { 2, "94 Murray St, Tanunda, SA", "Tanunda", new DateTimeOffset(new DateTime(2023, 11, 11, 21, 12, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Australian", "Barbeque Nation 2", -34.522849999999998, 138.96106, "1918 Bistro & Grill", new List<string> { "https://media1.agfg.com.au/images/listing/4939/gallery/1918-bistro-grill-12.jpg" }, 10, 0 },
                    { 3, "49289 Us-30, Westport, OR 97016", "Clatskanie", new DateTimeOffset(new DateTime(2023, 2, 11, 8, 12, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "American", "Barbeque Nation 3", 46.130690000000001, -123.37356, "Berry Patch Restaurant", new List<string> { "https://media-cdn.tripadvisor.com/media/photo-o/0c/8e/f8/2d/exterior.jpg", "https://img.delicious.com.au/4P8g_XLF/del/2022/02/vibrant-chickpea-burgers-163338-2.jpg" }, 10, 0 },
                    { 4, "350 Hepburn-Newstead Road, Hepburn Springs, VIC", "Hepburn Springs", new DateTimeOffset(new DateTime(2023, 1, 11, 9, 12, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Italian", "Barbeque Nation 4", -37.272765700000001, 144.10972509999999, "La Trattoria of Lavandula", new List<string> { "https://www.bestrestaurants.com.au/media/s5jpvkl4/2.jpg?width=1200&rnd=132864454952100000", "https://www.lifegate.com/app/uploads/piadina.jpg" }, 10, 0 },
                    { 5, "135 W. Main Street, Fernley, NV 89408", "Fernley", new DateTimeOffset(new DateTime(2023, 1, 6, 11, 12, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mexican", "Barbeque Nation 5", 39.607551200000003, -119.25278640000001, "Jehova es Mi Pastor Tacos y Burritos", new List<string> { "https://s3-media0.fl.yelpcdn.com/bphoto/fWCgiPBAAoF_8i-aXxwl9g/l.jpg" }, 10, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, "apinwill0@typepad.com", "esf043KS", "Arte" },
                    { 2, "abeed1@ebay.com", "ES11dsfGR", "Arsfdel" },
                    { 3, "nsummerskill2@miitbeian.gov.cn", "SNsuifePX", "Novelia" },
                    { 4, "bfairholm3@github.com", "asd%2222", "Beale" },
                    { 5, "whabeshaw4@merriam-webster.com", "4857fea645", "Win" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
