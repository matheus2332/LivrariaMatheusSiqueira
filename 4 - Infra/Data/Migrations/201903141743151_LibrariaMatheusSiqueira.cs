namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibrariaMatheusSiqueira : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Genero");
        }
    }
}
