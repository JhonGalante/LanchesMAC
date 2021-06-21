using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesMAC.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //categorias
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Normal','Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Natural','Lanche feito com ingredientes integrais e naturais')");

            //lanches
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Normal'),'Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',1, 'https://s2.glbimg.com/zYzXCkcHKEmmocDtLOzchVgDI80=/0x0:248x203/984x0/smart/filters:strip_icc()/s.glbimg.com/po/rc/media/2012/12/19/21_32_24_757_download_1_.jpg','https://s2.glbimg.com/zYzXCkcHKEmmocDtLOzchVgDI80=/0x0:248x203/984x0/smart/filters:strip_icc()/s.glbimg.com/po/rc/media/2012/12/19/21_32_24_757_download_1_.jpg', 1 ,'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Normal'),'Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.',1,'https://www.hellmanns.com.br/content/dam/unilever/global/recipe_image/116/11673/116733-default.jpg/_jcr_content/renditions/cq5dam.web.800.600.jpeg','https://www.hellmanns.com.br/content/dam/unilever/global/recipe_image/116/11673/116733-default.jpg/_jcr_content/renditions/cq5dam.web.800.600.jpeg',0,'Misto Quente', 8.00)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Normal'),'Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.',1,'https://s2.glbimg.com/jJirZVMNK5ZsZ9UDLKQBqPu3iXk=/620x455/e.glbimg.com/og/ed/f/original/2020/10/20/hamburgueria_bob_beef_-_dia_das_criancas_-_foto_pfz_studio__norma_lima.jpg','https://s2.glbimg.com/jJirZVMNK5ZsZ9UDLKQBqPu3iXk=/620x455/e.glbimg.com/og/ed/f/original/2020/10/20/hamburgueria_bob_beef_-_dia_das_criancas_-_foto_pfz_studio__norma_lima.jpg',0,'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Natural'),'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.',1,'https://cozinhalegal.com.br/files/receitas/787/Sanduiche-natural-fit-peito-peru.jpg','https://cozinhalegal.com.br/files/receitas/787/Sanduiche-natural-fit-peito-peru.jpg',1,'Lanche Natural Peito Peru', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
