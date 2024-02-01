﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceSampleClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UniqueEmails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Email",
                table: "Customer");
        }
    }
}
