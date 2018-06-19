namespace BaseSPA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creatabellarispostesondaggi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RisposteSondaggio",
                c => new
                    {
                        IdDomanda = c.Guid(nullable: false),
                        Punteggio = c.Int(nullable: false),
                        IdSondaggio = c.Guid(nullable: false),
                        IdDettaglio = c.Guid(nullable: false),
                        QuestionarioDettaglio_IdSondaggio = c.Guid(),
                        Sondaggio_IdSondaggio = c.Guid(),
                        Sondaggi_IdSondaggio = c.Guid(),
                    })
                .PrimaryKey(t => t.IdDomanda)
                .ForeignKey("dbo.Sondaggi", t => t.QuestionarioDettaglio_IdSondaggio)
                .ForeignKey("dbo.Sondaggi", t => t.Sondaggio_IdSondaggio)
                .ForeignKey("dbo.Sondaggi", t => t.Sondaggi_IdSondaggio)
                .ForeignKey("dbo.QuestionarioDettaglio", t => t.IdDettaglio, cascadeDelete: true)
                .Index(t => t.IdDettaglio)
                .Index(t => t.QuestionarioDettaglio_IdSondaggio)
                .Index(t => t.Sondaggio_IdSondaggio)
                .Index(t => t.Sondaggi_IdSondaggio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RisposteSondaggio", "IdDettaglio", "dbo.QuestionarioDettaglio");
            DropForeignKey("dbo.RisposteSondaggio", "Sondaggi_IdSondaggio", "dbo.Sondaggi");
            DropForeignKey("dbo.RisposteSondaggio", "Sondaggio_IdSondaggio", "dbo.Sondaggi");
            DropForeignKey("dbo.RisposteSondaggio", "QuestionarioDettaglio_IdSondaggio", "dbo.Sondaggi");
            DropIndex("dbo.RisposteSondaggio", new[] { "Sondaggi_IdSondaggio" });
            DropIndex("dbo.RisposteSondaggio", new[] { "Sondaggio_IdSondaggio" });
            DropIndex("dbo.RisposteSondaggio", new[] { "QuestionarioDettaglio_IdSondaggio" });
            DropIndex("dbo.RisposteSondaggio", new[] { "IdDettaglio" });
            DropTable("dbo.RisposteSondaggio");
        }
    }
}
