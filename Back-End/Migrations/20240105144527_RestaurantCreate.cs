using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Back_End.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Cuisines = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    PhotosUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "City", "Cuisines", "Description", "Name", "PhotosUrl" },
                values: new object[,]
                {
                    { 2100702L, "2nd Floor, Adityam Building, Ulubari, Guwahati", "Guwahati", "North Indian", "Barbeque Nation is a restaurant that goes above and beyond the �unlimited food� experience. The brand strives to deliver a great customer experience. So the reinvented BBQ Nation is another step in that direction.", "Barbeque Nation", "https://www.businessinsider.in/photo/81662629/barbeque-nation-ipo-issues-opens-today-should-you-subscribe.jpg" },
                    { 16604896L, "350 Hepburn-Newstead Road, Hepburn Springs, VIC", "Hepburn Springs", "Italian, Fusion, Cafe", "Barbeque Nation 4", "La Trattoria of Lavandula", "https://www.bestrestaurants.com.au/media/s5jpvkl4/2.jpg?width=1200&rnd=132864454952100000" },
                    { 16604897L, "49289 Us-30, Westport, OR 97016", "Clatskanie", "American, Breakfast, Desserts", "Barbeque Nation 3", "Berry Patch Restaurant", "https://media-cdn.tripadvisor.com/media/photo-o/0c/8e/f8/2d/exterior.jpg" },
                    { 16608059L, "94 Murray St, Tanunda, SA", "Tanunda", "Modern Australian, Australian", "Barbeque Nation 2", "1918 Bistro & Grill", "https://media1.agfg.com.au/images/listing/4939/gallery/1918-bistro-grill-12.jpg" },
                    { 17536645L, "135 W. Main Street, Fernley, NV 89408", "Fernley", "Mexican", "Barbeque Nation 5", "Jehova es Mi Pastor Tacos y Burritos", "https://s3-media0.fl.yelpcdn.com/bphoto/fWCgiPBAAoF_8i-aXxwl9g/l.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
