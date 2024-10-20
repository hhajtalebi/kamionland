using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlideManagement.Infrastucture.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class initSlide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Picturefull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picturethum = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PictureAlte = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureTitel = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    BtnText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanonicalId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slide");
        }
    }
}
