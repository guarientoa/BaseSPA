namespace BaseSPA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatabelladomandeQuestionario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionarioDettaglio",
                c => new
                    {
                        IdDettaglio = c.Guid(nullable: false),
                        Domanda = c.String(),
                        IdQuestionario = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdDettaglio)
                .ForeignKey("dbo.Questionari", t => t.IdQuestionario, cascadeDelete: true)
                .Index(t => t.IdQuestionario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionarioDettaglio", "IdQuestionario", "dbo.Questionari");
            DropIndex("dbo.QuestionarioDettaglio", new[] { "IdQuestionario" });
            DropTable("dbo.QuestionarioDettaglio");
        }
    }
}
