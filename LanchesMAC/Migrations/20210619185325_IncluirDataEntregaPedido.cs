using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesMAC.Migrations
{
    public partial class IncluirDataEntregaPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProdutoEntregueEm",
                table: "Pedidos",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoEntregueEm",
                table: "Pedidos");
        }
    }
}
