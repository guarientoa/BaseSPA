namespace BaseSPA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatatabellaQuestionari : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questionari",
                c => new
                    {
                        IdQuestionario = c.Guid(nullable: false),
                        Titolo = c.String(),
                    })
                .PrimaryKey(t => t.IdQuestionario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questionari");
        }
    }
}
