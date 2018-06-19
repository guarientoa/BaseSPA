namespace BaseSPA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creatabellasondaggi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sondaggi",
                c => new
                    {
                        IdSondaggio = c.Guid(nullable: false),
                        Note = c.String(),
                        IdQuestionario = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdSondaggio)
                .ForeignKey("dbo.Questionari", t => t.IdQuestionario, cascadeDelete: true)
                .Index(t => t.IdQuestionario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sondaggi", "IdQuestionario", "dbo.Questionari");
            DropIndex("dbo.Sondaggi", new[] { "IdQuestionario" });
            DropTable("dbo.Sondaggi");
        }
    }
}
