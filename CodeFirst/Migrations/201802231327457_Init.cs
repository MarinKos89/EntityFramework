namespace Zadatak72.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kolegiji",
                c => new
                    {
                        IDKolegij = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 120),
                        SkraceniNaziv = c.String(maxLength: 30),
                        ECTSbodova = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDKolegij);
            
            CreateTable(
                "dbo.Studenti",
                c => new
                    {
                        IDStudent = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 30),
                        Prezime = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IDStudent);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Studenti");
            DropTable("dbo.Kolegiji");
        }
    }
}
