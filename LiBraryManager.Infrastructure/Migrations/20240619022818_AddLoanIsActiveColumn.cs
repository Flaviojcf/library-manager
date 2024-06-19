﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiBraryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanIsActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Loans");
        }
    }
}
