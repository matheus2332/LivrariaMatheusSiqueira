namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibrariaMatheusSiqueira3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livro", "DataDeEdicao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livro", "DataDeEdicao");
        }
    }
}
