namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibrariaMatheusSiqueira4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Livro", "DataDeEdicao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Livro", "DataDeEdicao", c => c.DateTime(nullable: false));
        }
    }
}
