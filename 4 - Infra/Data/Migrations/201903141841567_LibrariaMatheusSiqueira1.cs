namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibrariaMatheusSiqueira1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AnoDePublicacao = c.Int(),
                        Autor = c.String(),
                        AutoresSecundarios = c.String(),
                        Editora = c.String(),
                        GeneroId = c.Guid(nullable: false),
                        Isbn = c.String(),
                        NumeroDaEdicao = c.Int(),
                        NumeroDePaginas = c.Int(),
                        QuantidadeEmEstoque = c.Int(nullable: false),
                        Serie = c.String(),
                        SubTitulo = c.String(),
                        Titulo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genero", t => t.GeneroId)
                .Index(t => t.GeneroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "GeneroId", "dbo.Genero");
            DropIndex("dbo.Livro", new[] { "GeneroId" });
            DropTable("dbo.Livro");
        }
    }
}
