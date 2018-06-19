namespace BaseSPA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creatabellesurvey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.String(),
                        AnswerText = c.String(),
                        dtAgg = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SurveyId = c.Int(nullable: false),
                        QuestionText = c.String(),
                        Type = c.String(),
                        Sorting = c.Int(),
                        dtAgg = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Survey", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Subtitle = c.String(),
                        Description = c.String(),
                        Notes = c.String(),
                        dtAgg = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "Id", "dbo.Survey");
            DropForeignKey("dbo.Answer", "Id", "dbo.Question");
            DropIndex("dbo.Question", new[] { "Id" });
            DropIndex("dbo.Answer", new[] { "Id" });
            DropTable("dbo.Survey");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
