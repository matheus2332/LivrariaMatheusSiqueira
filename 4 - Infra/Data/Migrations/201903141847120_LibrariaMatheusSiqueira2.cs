namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibrariaMatheusSiqueira2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livro", "DataDeCadastro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livro", "DataDeCadastro");
        }
    }
}
